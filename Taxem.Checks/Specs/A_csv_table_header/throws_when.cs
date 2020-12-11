namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using JPI;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class throws_when
   {
      public void it_is_empty()
      {
         var table = CSV.Table(Disposable.Of(() => new StringReader(Empty)));

         Calling(() => table.Header().Result())
            .Throws<InvalidDataException>()
            .WithMessage("The text appears to be empty.");
      }

      public void it_contains_no_commas()
      {
         var table = CSV.Table(Disposable.Of(() => new StringReader(HeaderContainsNoCommas)));

         Calling(() => _ = table.Header().Result())
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table header.");
      }

      public void it_contains_consecutive_commas()
      {
         var table = CSV.Table(Disposable.Of(() => new StringReader(HeaderContainsConsecutiveCommas)));

         Calling(() => _ = table.Header().Result())
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table header.");
      }
   }
}
