namespace Taxem
{
   using System.IO;

   public static class CSV
   {
      public static CSVTable Table(TextReader text) => new CSVTableFromText(text);

      public static CSVTable Table(string path) => new CSVTableFromFile(path);
   }
}
