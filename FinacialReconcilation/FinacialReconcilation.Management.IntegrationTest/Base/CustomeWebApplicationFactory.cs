using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;

namespace FinacialReconcilation.Management.IntegrationTest.Base
{
    public class CustomWebApplicationFactory<TStartup>
            : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();
                };
            });
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }


        public async Task<T> UploadFileAndResult<T>(HttpClient clientfactory, T result, string endpoint)
        {
            // please specify the directory on c path
            var currentDirectory = Directory.GetCurrentDirectory();
            var filePath = System.IO.Path.Combine(currentDirectory, "Uploads");

            var filesInDir = Directory.GetFiles(filePath);

            if (filesInDir.Where(f => f.EndsWith(".csv")).Count() == 2)
            {
                byte[] Firstbytes = File.ReadAllBytes(filesInDir[0]);

                var byteArrayContentF1 = new ByteArrayContent(Firstbytes);
                byteArrayContentF1.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");

                byte[] Secondbytes = File.ReadAllBytes(filesInDir[1]);

                var byteArrayContentSecond = new ByteArrayContent(Secondbytes);
                byteArrayContentSecond.Headers.ContentType = MediaTypeHeaderValue.Parse("text/csv");
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(byteArrayContentF1, "firstFile", "firstFile.csv");
                    content.Add(byteArrayContentSecond, "secondFile", "secondFile.csv");

                    using (var message = await clientfactory.PostAsync(endpoint, content))
                    {
                        var input = await message.Content.ReadAsStringAsync();

                        result = JsonConvert.DeserializeObject<T>(input);
                    }
                }

            }

            return result;
        }

    }
}
