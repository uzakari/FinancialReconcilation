using CsvHelper;
using Microsoft.AspNetCore.Http;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using Reconcilation.Management.Application.Models.File;
using Reconcilation.Management.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Helpers
{
    public static class FileHelper
    {
        public static List<FileFormat> GetFileContent(IFormFile firstFile)
        {
            var fileContentResponse = new List<FileFormat>();

            using (var streamReader = new StreamReader(firstFile.OpenReadStream()))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<FileFormatMap>();

                    fileContentResponse = csvReader.GetRecords<FileFormat>().Distinct().ToList();

                }
            }

            return fileContentResponse;
        }


        public static HashSet<FileFormat> RemoveDuplicate(List<FileFormat> contents)
        {
            var filesContent = new HashSet<FileFormat>(new FileComparer());

            foreach (var item in contents)
            {

                filesContent.Add(item);

            }

            return filesContent;
        }

        public static IEnumerable<FileFormatProjection> MatchedRecords(List<FileFormat> firstFile, List<FileFormat> secondFile)
        {
            return firstFile.Join(secondFile, f => new
            {
                f.ProfileName,
                f.TransactionId,
                f.TransactionAmount,
                f.TransactionDate,
                f.TransactionDescription,
                f.TransactionNarrative,
                f.WalletReference,
                f.TransactionType
            }, s => new
            {
                s.ProfileName,
                s.TransactionId,
                s.TransactionAmount,
                s.TransactionDate,
                s.TransactionDescription,
                s.TransactionNarrative,
                s.WalletReference,
                s.TransactionType
            }, (f, s) => new FileFormatProjection
            {
                firstFile = f,
                secondFile = s
            });
        }


        public static IEnumerable<FileFormatProjection> PartialMatchedRecords(List<FileFormat> firstFile, List<FileFormat> secondFile)
        {
            return firstFile.Join(secondFile, f => new
            {
                f.TransactionDate,
                f.WalletReference,
                f.TransactionType
            }, s => new
            {
                s.TransactionDate,
                s.WalletReference,
                s.TransactionType
            }, (f, s) => new FileFormatProjection
            {
                firstFile = f,
                secondFile = s
            });
        }


        public static UnmatchFileResultVm GetUnmatchRecord(IEnumerable<FileFormat> unmatchRecordFirst, string filename)
        {
            var unmatchFileResultVm = new UnmatchFileResultVm();

            unmatchFileResultVm.FileName = filename;

            foreach (var item in unmatchRecordFirst)
            {
                var mapFileFormat = new UnmatchFileResultContent { Date = item.TransactionDate, Amount = item.TransactionAmount, Reference = item.WalletReference };

                unmatchFileResultVm.UnmatchFileResultContents.Add(mapFileFormat);

            }

            return unmatchFileResultVm;
        }


        public static IEnumerable<FileFormat> FilterUnmatchRecords(List<FileFormat> listToReturn, List<FileFormat> listToExemptContent)
        {
            return listToReturn.Except(listToExemptContent, new FileComparer());
        }

    }

}
