namespace Taxem
{
   using System;
   using System.Collections.Generic;
   using System.Linq;
   using System.Windows;
   using Caliburn.Micro;
   using JPI;

   public class RootViewModel : Screen
   {
      private IReadOnlyList<TransactionViewModel> transactions;

      public RootViewModel() => transactions = new NoTransactionViewModel().InList();

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

      public void Drop(DragEventArgs e)
      {
         var file = ((string[])e.NotNull().Data.GetData(DataFormats.FileDrop))[0];
         Transactions = new CSVTransactions(file)
            .Select(transaction => new LoadedTransactionViewModel(transaction))
            .ToList();
      }
   }
}
