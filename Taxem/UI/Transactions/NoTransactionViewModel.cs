namespace Taxem
{
   using Caliburn.Micro;

   public sealed class NoTransactionViewModel : TransactionViewModel
   {
      private const string text = "Drag and drop a CSV file...";

      public string Text { get; } = text;
   }
}
