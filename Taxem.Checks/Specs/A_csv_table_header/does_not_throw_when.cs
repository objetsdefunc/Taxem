﻿namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class does_not_throw_when
   {
      [Fact]
      public void it_is_valid_csv()
      {
         using var text = new StringReader(ValidTransactions);
         using var table = CSV.Table(text);

         Calling(() => table.Header())
            .DoesNotThrow();
      }
   }
}
