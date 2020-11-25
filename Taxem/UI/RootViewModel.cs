namespace Taxem
{
   using System.Collections.Generic;
   using System.Linq;
   using Caliburn.Micro;

   public class RootViewModel : Screen
   {
      private IReadOnlyList<TransactionViewModel> fills;

      public RootViewModel() =>
         fills = new CSVTransactions(@"D:\Taxes\Crypto\fills.csv")
            .Select(transaction => new TransactionViewModel(transaction))
            .ToList();

      public IReadOnlyList<TransactionViewModel> Fills
      {
         get => fills;
         set
         {
            if (value != fills)
            {
               fills = value;
               NotifyOfPropertyChange(() => Fills);
            }
         }
      }
   }
}
