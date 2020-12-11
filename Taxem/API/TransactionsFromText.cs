namespace Taxem
{
   using System;
   using System.IO;
   using JPI;

   public sealed class TransactionsFromText : IObservable<Row>, IDisposable
   {
      private readonly CSVTable table;

      internal TransactionsFromText(IDisposing<TextReader> textReader) =>
         this.table = new CSVTableFromText(textReader);

      public IDisposable Subscribe(IObserver<Row> observer) =>
         table.Rows().Subscribe(observer);

      public void Dispose() => table.Dispose();
   }
}
