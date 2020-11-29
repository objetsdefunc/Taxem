﻿namespace A_csv_table_header
{
   using System.IO;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;
   using static Taxem.Checks.Properties.Resources;

   public class throws_when
   {
      [Fact]
      public void it_is_empty()
      {
         using var text = new StringReader(Empty);
         using var table = CSV.Table(text);

         Calling(() => table.Header())
            .Throws<InvalidDataException>()
            .WithMessage("The text appears to be empty.");
      }

      [Fact]
      public void it_contains_no_commas()
      {
         using var text = new StringReader(HeaderContainsNoCommas);
         using var table = CSV.Table(text);

         Calling(() => _ = table.Header().Result)
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table header.");
      }

      [Fact]
      public void it_contains_consecutive_commas()
      {
         using var text = new StringReader(HeaderContainsConsecutiveCommas);
         using var table = CSV.Table(text);

         Calling(() => _ = table.Header().Result)
            .Throws<InvalidDataException>()
            .WithMessage("The text doesn't appear to be a valid table header.");
      }
   }
}
