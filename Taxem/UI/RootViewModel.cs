namespace Taxem
{
   using System.Collections.Generic;
   using System.Linq;
   using Caliburn.Micro;

   public class RootViewModel : Screen
   {
      private IReadOnlyList<string> fills;

      public RootViewModel() =>
         fills = new CSVTransactions(@"D:\Taxes\Crypto\fills.csv")
            .Select(transaction => transaction.Text())
            .ToList();

      public IReadOnlyList<string> Fills
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
