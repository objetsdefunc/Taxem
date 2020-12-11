namespace Taxem
{
   using System;
   using System.IO;
   using JPI;

   internal class TransactionsFromFile : IObservable<Row>
   {
      private readonly IObservable<Row> rows;

      internal TransactionsFromFile(FilePath file) =>
         rows = new TransactionsFromText(
            Disposable.Of(() => new StreamReader(File.OpenRead(file.Path.AsPrimitive))));

      public IDisposable Subscribe(IObserver<Row> observer) =>
         rows.Subscribe(observer);
   }
}
