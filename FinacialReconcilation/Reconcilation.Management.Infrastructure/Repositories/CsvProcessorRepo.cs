using CsvHelper;
using Microsoft.Extensions.Logging;
using Reconcilation.Management.Application.Contracts.Infrastructure;
using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using Reconcilation.Management.Application.Models.File;
using Reconcilation.Management.Infrastructure.Helpers;
using Reconcilation.Management.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Repositories
{
    public class CsvProcessorRepo : ICsvProcessor
    {

        private readonly ILogger<CsvProcessorRepo> _logger;

        private List<UnmatchFileResultVm> unmatchFileResultVms;
        public CsvProcessorRepo(ILogger<CsvProcessorRepo> logger)
        {
            _logger = logger;
        }
        public byte[] ExportUnmatchRecords()
        {

            if (unmatchFileResultVms.Count > 0)
            {
                using var memoryStream = new MemoryStream();
                using (var streamWriter = new StreamWriter(memoryStream))
                {
                    using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(unmatchFileResultVms);
                }

                return memoryStream.ToArray();

            }

            return new byte[0];

        }

        public Task<List<UnmatchFileResultVm>> GetUnmatchFileResultUploaded(UnmatchResultQuery unmatchResultQuery)
        {
            var unmatchFileResultResponse = new List<UnmatchFileResultVm>();


            try
            {


                _logger.LogInformation("About to get the content of the first file");

                var firstFile = FileHelper.GetFileContent(unmatchResultQuery.FirstFile);

                _logger.LogInformation("About to get the content of the second file");

                var secondFile = FileHelper.GetFileContent(unmatchResultQuery.SecondFile);


                var firstFileWithNoDuplicate = FileHelper.RemoveDuplicate(firstFile).ToList();

                var secondFileWithNoDuplicate = FileHelper.RemoveDuplicate(secondFile).ToList();

                var unmatchRecordFirst = firstFileWithNoDuplicate.Except(secondFileWithNoDuplicate, new FileComparer());

                var unmatchRecordSecond = secondFileWithNoDuplicate.Except(firstFileWithNoDuplicate, new FileComparer());

                var firstFileTransformContent = FileHelper.GetUnmatchRecord(unmatchRecordFirst, unmatchResultQuery?.FirstFile.FileName);

                var secondFileTransformContent = FileHelper.GetUnmatchRecord(unmatchRecordSecond, unmatchResultQuery?.SecondFile.FileName);

                unmatchFileResultResponse.Add(firstFileTransformContent);

                unmatchFileResultResponse.Add(secondFileTransformContent);

            }
            catch (Exception ex)
            {

                _logger.LogCritical("An Exception occured while runing GetUnmatchFileResultUploaded {ex} ", ex);
            }



            return Task.FromResult(unmatchFileResultResponse);
        }

     

        public Task<List<FileCompareDto>> ProcessUploadedCsvFile(GetFilesCompareQuery files)
        {
            var fileListCompareResult = new List<FileCompareDto>();

            try
            {
                _logger.LogInformation("About to get the content of the first file");

                var firstFile = FileHelper.GetFileContent(files.FirstFile);

                _logger.LogInformation("About to get the content of the second file");

                var secondFile = FileHelper.GetFileContent(files.SecondFile);

                var firstFileWithNoDuplicate = FileHelper.RemoveDuplicate(firstFile).ToList();

                var secondFileWithNoDuplicate = FileHelper.RemoveDuplicate(secondFile).ToList();

                var matchingRecored = FileHelper.MatchedRecords(firstFile, secondFile);

                // we can try to reduce the nuber of checks for partial match records

                var partialMatchedRecords = FileHelper.PartialMatchedRecords(firstFileWithNoDuplicate, secondFileWithNoDuplicate);

                var unmatchRecordFirst = firstFileWithNoDuplicate.Except(secondFileWithNoDuplicate, new FileComparer());

                var unmatchRecordSecond = secondFileWithNoDuplicate.Except(firstFileWithNoDuplicate, new FileComparer());


                fileListCompareResult.Add(new FileCompareDto
                {
                    FileName = files.FirstFile.FileName,
                    MatchingRecords = matchingRecored.Count(),
                    TotalRecords = firstFile.Count,
                    UnmatchingRecords = unmatchRecordFirst.Count(),
                    PartialMatchRecords =partialMatchedRecords.Count()

                });

                fileListCompareResult.Add(new FileCompareDto
                {
                    FileName = files.SecondFile.FileName,
                    MatchingRecords = matchingRecored.Count(),
                    TotalRecords = secondFile.Count,
                    UnmatchingRecords = unmatchRecordSecond.Count(),
                    PartialMatchRecords = partialMatchedRecords.Count()

                });
            }
            catch (Exception ex)
            {

                _logger.LogCritical("An Exception occured while runing ProcessUploadedCsvFile {ex} ", ex);
            }

            return Task.FromResult(fileListCompareResult);
        }

    


    }
}
