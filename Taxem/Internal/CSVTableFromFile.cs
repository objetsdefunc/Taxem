namespace Taxem
{
   using System;
   using System.IO;
   using System.Threading.Tasks;

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

      public Task<Header> Header() => text.Header();

      public IObservable<string> Rows() => text.Rows();

      public void Dispose()
      {
         file.Dispose();
         text.Dispose();
      }
   }
}
