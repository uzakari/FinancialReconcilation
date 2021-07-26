using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Moq;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Reconcilation.Management.Unittest.Mocks
{
    public static class RepositoryMocks
    {
        public static UnmatchResultQuery unmatchResultQuery = new UnmatchResultQuery();

        public static Mock<ICsvProcessor> GetCSvProcessorRepository()
        {
            var filesInDir = Directory.GetFiles("C:/Users/isau/Documents/Learning/Tutuka_Project/FinacialReconcilation/FileUploadTest");

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
