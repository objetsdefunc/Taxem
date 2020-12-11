namespace Taxem
{
   using System;
   using System.IO;
   using JPI;

   public static class TransactionSequence
   {
      public static IObservable<Row> From(IDisposing<TextReader> text) => new TransactionsFromText(text);

      public static IObservable<Row> From(FilePath path) => new TransactionsFromFile(path);
   }
}
