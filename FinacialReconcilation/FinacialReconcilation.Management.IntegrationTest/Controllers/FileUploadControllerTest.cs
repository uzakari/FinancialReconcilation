using GloboTicket.TicketManagement.API.IntegrationTests.Base;
using Newtonsoft.Json;
using Reconcilation.Management.Api;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
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
        public async Task UploadFileAndGetCompareVmTest()
        {
            var clientfactory = _factory.GetAnonymousClient();

            var result = new FileCompareResultVm();

            var endpoint = "/api/FileUpload";

            result = await _factory.UploadFileAndResult(clientfactory, result, endpoint);

            Assert.IsType<FileCompareResultVm>(result);
        }

        [Fact]
        public async Task GetUnmatchFileRecordVmTest()
        {
            var clientfactory = _factory.GetAnonymousClient();

            var result = new List<UnmatchFileResultVm>();

            var endpoint = "/api/FileUpload/unmatchfileresult";

            result = await _factory.UploadFileAndResult(clientfactory, result, endpoint);

            Assert.IsType<List<UnmatchFileResultVm>>(result);
        }



    }
}

