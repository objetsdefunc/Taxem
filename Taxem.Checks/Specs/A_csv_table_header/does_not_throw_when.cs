namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using JPI;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class does_not_throw_when
   {
      [Fact]
      public void it_is_valid_csv()
      {
         var table = CSV.Table(Disposable.Of(() => new StringReader(ThreeValidTransactions)));

         Calling(() => table.Header())
            .DoesNotThrow();
      }
   }
}
