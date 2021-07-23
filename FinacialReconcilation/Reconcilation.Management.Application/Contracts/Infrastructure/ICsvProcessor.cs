using Reconcilation.Management.Application.Features.FileParser.Query.CompareFile;
using Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Contracts.Infrastructure
{
    public interface ICsvProcessor
    {
        byte[] ExportUnmatchRecords();

        Task<List<FileCompareDto>> ProcessUploadedCsvFile(GetFilesCompareQuery files);

        Task<List<UnmatchFileResultVm>> GetUnmatchFileResultUploaded(UnmatchResultQuery unmatchResultQuery);
    }
}
