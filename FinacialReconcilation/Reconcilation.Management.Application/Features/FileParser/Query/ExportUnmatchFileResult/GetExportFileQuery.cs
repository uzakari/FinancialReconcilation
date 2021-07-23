using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.ExportUnmatchFileResult
{
    public class GetExportFileQuery: IRequest<ExportFileVm>
    {
    }
}
