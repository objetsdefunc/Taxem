namespace Taxem
{
   using System;
   using System.IO;
   using System.Linq;

   public sealed class CSVTable
   {
      private readonly Lazy<object> header;

      public CSVTable(TextReader text)
      {
         _ = text ?? throw new ArgumentNullException(nameof(text));

         header = new Lazy<object>(
            () =>
            {
               var header = text.ReadLine();

               return
                  !header.Contains(",") ||
                  header.Split(',').Where(column => column.Trim().Length == 0).Any()
                     ? throw new InvalidDataException(
                        "The text doesn't appear to be a valid table header.")
                     : header;
            });
      }

      public object Header() => header.Value;
   }
}
