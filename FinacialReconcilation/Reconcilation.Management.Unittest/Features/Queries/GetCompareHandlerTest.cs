using Moq;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using Reconcilation.Management.Unittest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Reconcilation.Management.Unittest.Features.Queries
{
    public class GetCompareHandlerTest
    {

        private readonly Mock<ICsvProcessor> _mockCsvProssesorRepo;


        public GetCompareHandlerTest()
        {

            _mockCsvProssesorRepo = RepositoryMocks.GetCSvProcessorRepository();

        }

        [Fact]
        public async Task GetFileComparisonTest()
        {
            var handler = new GetFileCompareHandler(_mockCsvProssesorRepo.Object);

            var result = await handler.Handle(new GetFilesCompareQuery(), CancellationToken.None);

            result.ShouldBeOfType<FileCompareResultVm>();
        }

        [Fact]
        public async Task UnmatchFileResultTest()
        {
            var handler = new UnmatchFileResultHandler(_mockCsvProssesorRepo.Object);

            var result = await handler.Handle(new UnmatchResultQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<UnmatchFileResultVm>>();
        }
    }
}
