namespace Taxem
{
   using System;
   using System.Collections;
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.IO;
   using System.Linq;

   internal sealed class CSVTransactions : Transactions
   {
      private readonly Lazy<List<Transaction>> transactions;

      internal CSVTransactions(string path)
      {
         transactions = new Lazy<List<Transaction>>(
            () =>
            {
               using (var reader = new StreamReader(File.OpenRead(path)))
               {
                  var transactions = new List<Transaction>();

                  while (!reader.EndOfStream)
                  {
                     transactions.Add(new Transaction(reader.ReadLine()));
                  }

                  Debug.Assert(transactions.First().Text() == "size size unit", "The columns are not where you thought they were.");

                  return transactions.Skip(1).ToList();
               }
            });
      }

      public int Count => transactions.Value.Count;

      public IEnumerator<Transaction> GetEnumerator() => transactions.Value.GetEnumerator();

      IEnumerator IEnumerable.GetEnumerator() => transactions.Value.GetEnumerator();
   }
}
