namespace Taxem
{
   using System.Collections.Generic;
   using Caliburn.Micro;

   public class RootViewModel : Screen
   {
      private IReadOnlyList<string> fills = new List<string>();

      public RootViewModel()
      {
         fills = new CSVFile(@"D:\Taxes\Crypto\fills.csv").Transactions();
      }

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
