namespace Taxem
{
   using Caliburn.Micro;

   public sealed class LoadedTransactionViewModel : TransactionViewModel
   {
      private readonly Transaction transaction;

      public LoadedTransactionViewModel(Transaction transaction) => this.transaction = transaction;

      public string Text => transaction.Text();
   }
}
