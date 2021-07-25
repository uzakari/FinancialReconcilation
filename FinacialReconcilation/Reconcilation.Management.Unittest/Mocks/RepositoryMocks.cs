using Moq;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Unittest.Mocks
{
    public class RepositoryMocks
    {

        public static Mock<ICsvProcessor> GetCSvProcessorRepository()
        {

            var mockCsvProcessorRepository = new Mock<ICsvProcessor>();


            mockCsvProcessorRepository.Setup(repo => repo.ProcessUploadedCsvFile(It.IsAny<GetFilesCompareQuery>())).ReturnsAsync(
                (List<FileCompareDto> filesCompareQuery) =>
                {
                    return filesCompareQuery;
                });


            mockCsvProcessorRepository.Setup(repo => repo.GetUnmatchFileResultUploaded(It.IsAny<UnmatchResultQuery>())).ReturnsAsync(
            (List<UnmatchFileResultVm> unmatchFileResultVms) =>
            {
                return unmatchFileResultVms;
            });
            return mockCsvProcessorRepository;
        }

    }
}
