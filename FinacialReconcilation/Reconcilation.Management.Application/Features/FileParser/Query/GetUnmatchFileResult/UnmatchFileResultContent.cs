using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.GetUnmatchFileResult
{
    public class UnmatchFileResultContent
    {
        public DateTimeOffset Date { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }
    }
}
