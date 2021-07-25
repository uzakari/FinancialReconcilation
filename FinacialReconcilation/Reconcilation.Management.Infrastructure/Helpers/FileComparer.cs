using Reconcilation.Management.Application.Models.File;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reconcilation.Management.Infrastructure.Helpers
{
    public class FileComparer: IEqualityComparer<FileFormat>
    {

        public bool Equals(FileFormat x, FileFormat y)
        {

            return IsSame(x, y);
        }

        public int GetHashCode(FileFormat obj)
        {
            var fileObjectCompare = new
            {
                transId = obj.TransactionId.GetHashCode(),
                transAmount =  obj.TransactionAmount.GetHashCode(),
                transdate = obj.TransactionDate.GetHashCode(),
                transDescription = obj.TransactionDescription.GetHashCode(),
                walletReference = obj.WalletReference.GetHashCode(),
                transNarative = obj.TransactionNarrative.GetHashCode(),
                transType = obj.TransactionType.GetHashCode()
            };

            return fileObjectCompare.GetHashCode();
           
        }


        private bool IsSame(FileFormat x, FileFormat y)
        {
            return (x.TransactionId == y.TransactionId  && x.TransactionType == y.TransactionType 
                   && x.TransactionAmount == y.TransactionAmount && x.TransactionDate.UtcDateTime == y.TransactionDate.UtcDateTime
                            && x.TransactionDescription.ToLower().Trim() == y.TransactionDescription.ToLower().Trim() &&
                            x.TransactionNarrative.ToLower().Trim() == y.TransactionNarrative.ToLower().Trim() &&
                            x.WalletReference.ToLower().Trim().Length == y.WalletReference.ToLower().Trim().Length && x.WalletReference.ToLower().Trim() == y.WalletReference.ToLower().Trim());
        }



        
    }
}
