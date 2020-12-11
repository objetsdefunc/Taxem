namespace JPI
{
   using System;
   using System.IO;

   internal sealed class CSVTableFromFile : CSVTable, IDisposable
   {
      private readonly CSVTableFromText text;

      internal CSVTableFromFile(string path) =>
         text = new CSVTableFromText(
            Disposable.Of(() => new StreamReader(File.OpenRead(path))));

      public Future<Header> Header() => text.Header();

      public IObservable<Row> Rows() => text.Rows();

      public void Dispose() => text.Dispose();
   }
}
