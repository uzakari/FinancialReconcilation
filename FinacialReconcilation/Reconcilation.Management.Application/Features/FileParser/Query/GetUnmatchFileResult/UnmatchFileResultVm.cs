using Reconcilation.Management.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class UnmatchFileResultVm
    {
        public string FileName { get; set; }

        public List<UnmatchFileResultContent> UnmatchFileResultContents { get; set; } = new List<UnmatchFileResultContent>();

        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
