namespace Taxem
{
   using System.Collections.Generic;
   using System.Linq;
   using Caliburn.Micro;

   public class RootViewModel : Screen
   {
      private IReadOnlyList<TransactionViewModel> transactions;

      public RootViewModel() =>
         transactions = new CSVTransactions(@"D:\Taxes\Crypto\fills.csv")
            .Select(transaction => new TransactionViewModel(transaction))
            .ToList();

      public IReadOnlyList<TransactionViewModel> Transactions
      {
         get => transactions;
         set
         {
            if (value != transactions)
            {
               transactions = value;
               NotifyOfPropertyChange(() => Transactions);
            }
         }
      }
   }
}
