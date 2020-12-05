namespace Taxem
{
   using System;
   using System.IO;

   internal sealed class CSVTableFromFile : CSVTable, IDisposable
   {
      private readonly StreamReader file;
      private readonly CSVTableFromText text;

      internal CSVTableFromFile(string path)
      {
         file = new StreamReader(
            File.OpenRead(path ?? throw new ArgumentNullException(nameof(path))));

         text = new CSVTableFromText(file);
      }

      public Future<Header> Header() => text.Header();

      public IObservable<Row> Rows() => text.Rows();

      public void Dispose()
      {
         file.Dispose();
         text.Dispose();
      }
   }
}
