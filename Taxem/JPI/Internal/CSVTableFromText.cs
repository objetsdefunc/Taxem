namespace JPI
{
   using System;
   using System.IO;
   using System.Reactive.Linq;

   internal sealed class CSVTableFromText : CSVTable, IDisposable
   {
      private readonly IDisposable<TextReader> reader;
      private readonly Future<Header> header;
      private readonly IObservable<Row> rows;
      private readonly IDisposable readerLifetime;
      private readonly Lazy<IDisposable> connection;

      internal CSVTableFromText(IDisposing<TextReader> text)
      {
         reader = text.UseAsIDisposable();

         // All subscriptions will get all values.
         // Reading won't begin until a connection is established.
         var lines = Observable.Generate(
            string.Empty,
            line => line != null,
            _ => reader.Value.ReadLine(),
            line => line)
               .Replay();

         header = lines.FirstAsync().Select(row => new Header(row)).ToFuture();
         rows = lines.Skip(2).Select(line => new Row(line));

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
