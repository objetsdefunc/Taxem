namespace A_csv_table
{
   using System;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;

   public class throws_at_construction_when
   {
      [Fact]
      public void the_input_is_null() =>
         Calling(() => new CSVTable(null))
            .Throws<ArgumentNullException>().WithMessage("Value cannot be null.*'text'*");
   }
}
