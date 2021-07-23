using Reconcilation.Management.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class UnmatchFileResultVm: BaseResponse
    {
        public UnmatchFileResultVm():base()
        {

        }
        public string FileName { get; set; }

        public List<UnmatchFileResultContent> UnmatchFileResultContents { get; set; } = new List<UnmatchFileResultContent>();
    }
}
