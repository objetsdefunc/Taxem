﻿namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static Taxem.Checks.Properties.Resources;

   public class provides
   {
      [Fact]
      public async void all_its_column_headers()
      {
         using var text = new StringReader(ValidTransactions);
         using var table = CSV.Table(text);

         var foo = await table.Header();

         var columns = foo.Columns();

         columns.HasCount(11);
         columns[0].Is("portfolio");
         columns[9].Is("total");
      }
   }
}
