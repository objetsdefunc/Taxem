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
      public void a_row_contains_consecutive_commas()
      {
         using var text = new StringReader(ARowContainsConsecutiveCommas);
         using var table = CSV.Table(text);

         SubscribingTo(() => table.Rows())
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table row.");
      }

      internal void the_table_is_empty()
      {
         using var text = new StringReader(Empty);
         using var table = CSV.Table(text);

         Calling(() => table.Rows())
            .Throws<InvalidDataException>()
            .WithMessage("The text appears to be empty.");
      }

      internal void a_row_does_not_match_the_header_column_count()
      {
         using var text = new StringReader(ARowNotMatchingTheHeaderColumnCount);
         using var table = CSV.Table(text);

         SubscribingTo(() => _ = table.Rows())
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table header.");
      }
   }
}
