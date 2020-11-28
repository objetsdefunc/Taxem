namespace A_csv_table_header
{
   using System.IO;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class throws_when
   {
      [Fact]
      public void it_contains_no_commas()
      {
         using (var text = new StringReader(HeaderContainsNoCommas))
         {
            var document = new CSVTable(text);

            Calling(() => document.Header())
               .Throws<InvalidDataException>()
               .WithMessage("The text doesn't appear to be a valid table header.");
         }
      }

      [Fact]
      public void it_contains_consecutive_commas()
      {
         using (var text = new StringReader(HeaderContainsConsecutiveCommas))
         {
            var document = new CSVTable(text);

            Calling(() => document.Header())
               .Throws<InvalidDataException>()
               .WithMessage("The text doesn't appear to be a valid table header.");
         }
      }
   }
}
