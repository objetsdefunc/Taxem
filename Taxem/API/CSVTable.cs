namespace Taxem
{
   using System;
   using System.IO;
   using System.Reactive.Linq;
   using System.Reactive.Subjects;
   using System.Reactive.Threading.Tasks;
   using System.Threading.Tasks;

   public sealed class CSVTable : IDisposable
   {
      private readonly IConnectableObservable<string> rows;
      private readonly IDisposable disposable;

      public CSVTable(TextReader text)
      {
         _ = text ?? throw new ArgumentNullException(nameof(text));

         rows = Observable.Generate(
            text.ReadLine(),
            line => line != null,
            _ => text.ReadLine(),
            line => line)
               .Replay();

         disposable = rows.Connect();
      }

      public Task<Header> Header() =>
         rows.IsEmpty().Wait()
            ? throw new InvalidDataException("The text appears to be empty.")
            : rows.FirstAsync().Select(row => new Header(row)).ToTask();

      public IObservable<string> Rows() =>
         rows.IsEmpty().Wait()
            ? throw new InvalidDataException("The text appears to be empty.")
            : rows;

      public void Dispose() => disposable.Dispose();
   }
}
