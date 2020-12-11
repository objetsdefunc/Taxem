namespace Transactions_from_file
{
   using System.IO;
   using DefiniteAssertions;
   using JPI;
   using Taxem;
   using Xunit;
   using static DefiniteAssertions.DefiniteActions;

   public class throw_at_construction_when
   {
      [Fact]
      public void the_file_does_not_exist() =>
         Calling(
            () => TransactionSequence.From(FilePath.ThatExists(new Text("./ThisFileDoesNotExist.csv"))))
               .Throws<FileNotFoundException>();

      [Fact]
      public void the_file_is_empty() =>
         Calling(
            () => TransactionSequence.From(FilePath.ThatExists(new Text("./Resources/Empty.csv"))))
               .Throws<InvalidDataException>().WithMessage("The file is empty.");
   }
}
