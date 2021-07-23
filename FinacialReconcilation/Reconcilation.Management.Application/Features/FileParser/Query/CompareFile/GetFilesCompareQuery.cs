using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.CompareFile
{
    public class GetFilesCompareQuery: IRequest<FileCompareResultVm>
    {
        public IFormFile FirstFile { get; set; }

        public IFormFile SecondFile { get; set; }
    }
}
