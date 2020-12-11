namespace Transactions
{
   using System.IO;
   using System.Linq;
   using System.Reactive.Linq;
   using DefiniteAssertions;
   using JPI;
   using Taxem;
   using Xunit;
   using static Taxem.Checks.Properties.Resources;

   public class provide
   {
      [Fact]
      public void all_of_the_items_from_the_source()
      {
         var table = TransactionSequence.From(
            Disposable.Of(() => new StringReader(ThreeValidTransactions)));

         table.ToEnumerable().HasCount(3);
      }

      [Fact]
      public void all_of_the_items_each_time_asked()
      {
         var table = TransactionSequence.From(
            Disposable.Of(() => new StringReader(ThreeValidTransactions)));
         var forcedEnumeration = table.ToEnumerable().Count();

         table.ToEnumerable().HasCount(3);
      }
   }
}
