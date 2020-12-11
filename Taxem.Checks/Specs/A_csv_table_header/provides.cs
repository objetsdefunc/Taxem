namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using JPI;
   using Xunit;
   using static Taxem.Checks.Properties.Resources;

   public class provides
   {
      [Fact]
      public async void all_its_column_headers()
      {
         var table = CSV.Table(Disposable.Of(() => new StringReader(ThreeValidTransactions)));

         var foo = await table.Header();

         var columns = foo.Columns();

         columns.HasCount(11);
         columns[0].Is("portfolio");
         columns[9].Is("total");
      }
   }
}
