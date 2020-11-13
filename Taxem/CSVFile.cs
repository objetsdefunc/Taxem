namespace Taxem
{
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.IO;
   using System.Linq;

   internal sealed class CSVFile : TransactionFile
   {
      private readonly string path;

      internal CSVFile(string path)
      {
         this.path = path;
      }

      public IReadOnlyList<string> Transactions()
      {
         using (var reader = new StreamReader(File.OpenRead(path)))
         {
            var transactions = new List<Transaction>();

            while (!reader.EndOfStream)
            {
               transactions.Add(new Transaction(reader.ReadLine()));
            }

            Debug.Assert(transactions.First().Text() == "size size unit", "The columns are not where you thought they were.");

            return transactions.Skip(1).Select(t => t.Text()).ToList();
         }
      }
   }
}
