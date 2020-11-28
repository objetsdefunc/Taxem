namespace A_csv_tables_rows
{
   using System.IO;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;

   public class throw_when
   {
      [Fact]
      public void it_is_empty()
      {
         using var text = new StringReader(string.Empty);
         using var table = new CSVTable(text);

         Calling(() => table.Rows())
            .Throws<InvalidDataException>()
            .WithMessage("The text appears to be empty.");
      }
   }
}
