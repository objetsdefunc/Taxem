namespace A_csv_table_from_file
{
   using System;
   using System.IO;
   using DefiniteAssertions;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;

   public class throws_at_construction_when
   {
      [Fact]
      public void the_input_is_null() =>
         Calling(() => CSV.Table(null as string))
            .Throws<ArgumentNullException>().WithMessage("Value cannot be null.*'path'*");

      [Fact]
      public void the_file_does_not_exist() =>
         Calling(() => CSV.Table("./ThisFileDoesNotExist.csv"))
            .Throws<FileNotFoundException>();

      [Fact]
      public void the_file_is_empty() =>
         Calling(() => CSV.Table("./Empty.csv"))
            .Throws<FileNotFoundException>();
   }
}
