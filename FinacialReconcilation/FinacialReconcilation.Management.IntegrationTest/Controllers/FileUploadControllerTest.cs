using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using Newtonsoft.Json;
using Reconcilation.Management.Api;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FinacialReconcilation.Management.IntegrationTest.Controllers
{
    public class FileUploadControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public FileUploadControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task CheckHealtStateOfApi()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/health/live");

            response.EnsureSuccessStatusCode();

            Assert.Equal(200, (int)response.StatusCode);
        }

        [Fact]
        public async Task UploadFileTest()
        {
            var clientfactory = _factory.GetAnonymousClient();

            var result = new FileCompareResultVm();

            result = await UploadFileAndResult(clientfactory, result);
            Assert.IsType<FileCompareResultVm>(result);
        }

        private static async Task<T> UploadFileAndResult<T>(HttpClient clientfactory, T result)
        {
            var filesInDir = Directory.GetFiles("C:/Users/isau/Documents/Learning/Tutuka_Project/FinacialReconcilation/FileUploadTest");

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

                    using (var message = await clientfactory.PostAsync("/api/FileUpload", content))
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

