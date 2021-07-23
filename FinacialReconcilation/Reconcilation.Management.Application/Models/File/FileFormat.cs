using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Application.Models.File
{
    public class FileFormat
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }

        public DateTimeOffset TransactionDate { get; set; }

        public int TransactionAmount { get; set; }

        public string TransactionNarrative { get; set; }

        public string TransactionDescription { get; set; }

        public long TransactionId { get; set; }

        public int TransactionType { get; set; }

        public string WalletReference { get; set; }
    }
}
