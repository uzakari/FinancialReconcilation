using CsvHelper.Configuration;
using Reconcilation.Management.Application.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Models
{
    public class FileFormatMap:ClassMap<FileFormat>
    {
        public FileFormatMap()
        {
            Map(m => m.Id).Convert(row => row.Row.Context.Parser.RawRow);
            Map(m => m.ProfileName).Name("ProfileName");
            Map(m => m.TransactionAmount).Name("TransactionAmount");
            Map(m => m.TransactionDate).Name("TransactionDate");
            Map(m => m.TransactionDescription).Name("TransactionDescription");
            Map(m => m.TransactionNarrative).Name("TransactionNarrative");
            Map(m => m.TransactionType).Name("TransactionType");
            Map(m => m.TransactionId).Name("TransactionID");
            Map(m => m.WalletReference).Name("WalletReference");
        }
    }
}
