namespace Taxem
{
   using System;
   using System.IO;
   using System.Reactive.Linq;

   internal sealed class CSVTableFromText : CSVTable, IDisposable
   {
      private readonly TextReader reader;
      private readonly Future<Header> header;
      private readonly IObservable<Row> rows;
      private readonly IDisposable readerLifetime;
      private readonly Lazy<IDisposable> connection;

      internal CSVTableFromText(TextReader text)
      {
         reader = text ?? throw new ArgumentNullException(nameof(text));

         // All subscriptions will get all values.
         // Reading won't begin until a connection is established.
         var lines = Observable.Generate(
            text.ReadLine(),
            line => line != null,
            _ => text.ReadLine(),
            line => line)
               .Replay();

         header = lines.FirstAsync().Select(row => new Header(row)).ToFuture();
         rows = lines.Select(line => new Row(line));

         // Reader will be disposed as soon as all the lines have been read, or on error.
         readerLifetime = lines.LastAsync().Subscribe(
            _ => reader.Dispose(),
            ex => reader.Dispose());

         // The lines won't be read until needed.
         connection = new Lazy<IDisposable>(() => lines.Connect());
      }

      public Future<Header> Header() => connection.EnsuredBeforeReturning(header);

      public IObservable<Row> Rows() => connection.EnsuredBeforeReturning(rows);

      public void Dispose()
      {
         reader.Dispose();
         readerLifetime.Dispose();
         connection.Value.Dispose();
      }
   }
}
