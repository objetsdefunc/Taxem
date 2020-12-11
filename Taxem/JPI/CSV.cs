namespace JPI
{
   using System.IO;

   public static class CSV
   {
#pragma warning disable CA1062 // Validate arguments of public methods
      public static CSVTable Table(IDisposing<TextReader> text) => new CSVTableFromText(text);
#pragma warning restore CA1062 // Validate arguments of public methods

      public static CSVTable Table(string path) => new CSVTableFromFile(path);
   }
}
