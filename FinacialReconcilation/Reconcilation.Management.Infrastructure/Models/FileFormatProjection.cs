using Reconcilation.Management.Application.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Models
{
    public class FileFormatProjection
    {

        public FileFormat firstFile { get; set; }

        public FileFormat secondFile { get; set; }
    }
}
