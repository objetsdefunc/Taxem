namespace A_csv_tables_rows
{
   using System.IO;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class throw_when
   {
      [Fact]
      public void it_is_empty()
      {
         using var text = new StringReader(Empty);
         using var table = CSV.Table(text);

         Calling(() => table.Rows())
            .Throws<InvalidDataException>()
            .WithMessage("The text appears to be empty.");
      }
   }
}
