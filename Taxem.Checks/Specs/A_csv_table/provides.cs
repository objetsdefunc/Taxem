namespace A_csv_table
{
   using System.IO;
   using System.Linq;
   using System.Reactive.Linq;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static Taxem.Checks.Properties.Resources;

   public class provides
   {
      [Fact]
      public void all_its_rows()
      {
         using var text = new StringReader(ValidTransactions);
         using var table = CSV.Table(text);

         table.Rows().ToEnumerable().HasCount(4);
      }

      [Fact]
      public void all_its_rows_each_time()
      {
         using var text = new StringReader(ValidTransactions);
         using var table = CSV.Table(text);
         var forcedEnumeration = table.Rows().ToEnumerable().Count();

         table.Rows().ToEnumerable().HasCount(4);
      }
   }
}
