namespace A_csv_document
{
   using System.IO;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class throws_at_construction_when
   {
      [Fact]
      public void the_text_header_contains_no_commas()
      {
         var text = new StringReader(HeaderContainsNoCommas);

         Calling(() => new CSV(text))
            .Throws<InvalidDataException>().WithMessage("No commas found in the text.");
      }
   }
}
