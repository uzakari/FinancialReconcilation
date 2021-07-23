using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class UnmatchResultQuery: IRequest<List<UnmatchFileResultVm>>
    {

        public IFormFile FirstFile { get; set; }

        public IFormFile SecondFile { get; set; }
    }
}
