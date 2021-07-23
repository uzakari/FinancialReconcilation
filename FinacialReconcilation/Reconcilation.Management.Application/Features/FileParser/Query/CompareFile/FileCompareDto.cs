using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Features.FileParser.Query.CompareFile
{
    public class FileCompareDto
    {
        public string FileName { get; set; }

        public int TotalRecords { get; set; }

        public int MatchingRecords { get; set; }

        public int UnmatchingRecords { get; set; }
    }
}
