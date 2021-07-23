using Reconcilation.Management.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.CompareFile
{
    public class FileCompareResultVm: BaseResponse
    {
        public FileCompareResultVm():base()
        {

        }

        public List<FileCompareDto> fileCompareDtos { get; set; } = new List<FileCompareDto>();

    }
}
