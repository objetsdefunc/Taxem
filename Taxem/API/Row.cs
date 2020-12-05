namespace Taxem
{
   using System.IO;
   using System.Linq;

   public class Row
   {
      private readonly string[] entries;

      internal Row(string row)
      {
         entries = row.Split(',');

         if (entries.Where(entry => entry.Trim().Length == 0).Any())
         {
            throw new InvalidDataException("The text doesn't appear to be a valid table row.");
         }
      }
   }
}
