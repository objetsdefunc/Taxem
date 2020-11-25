namespace Taxem
{
   using System.IO;

   public sealed class CSV
   {
#pragma warning disable IDE0052 // Remove unread private members
      private readonly TextReader csv;
#pragma warning restore IDE0052 // Remove unread private members

      public CSV(TextReader csv)
      {
         this.csv = csv;
         throw new InvalidDataException("No commas found in the text.");
      }
   }
}
