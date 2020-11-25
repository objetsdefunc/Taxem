namespace Taxem
{
   using Caliburn.Micro;

   public class TransactionViewModel : Screen
   {
      private readonly Transaction transaction;

      public TransactionViewModel(Transaction transaction) => this.transaction = transaction;

      public string Text => transaction.Text();
   }
}
