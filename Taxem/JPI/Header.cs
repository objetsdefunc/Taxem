namespace JPI
{
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;

   public sealed class Header
   {
      private readonly string[] columns;

      internal Header(string header)
      {
         columns = header.Split(',');

         if (!header.Contains(",") ||
                  columns.Where(column => column.Trim().Length == 0).Any())
         {
            throw new InvalidDataException("The text doesn't appear to be a valid table header.");
         }
      }

      public IReadOnlyList<string> Columns() => columns;
   }
}
