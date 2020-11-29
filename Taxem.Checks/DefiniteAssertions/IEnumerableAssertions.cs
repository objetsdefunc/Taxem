namespace DefiniteAssertions
{
   using System.Collections;
   using FluentAssertions;

   public static class IEnumerableAssertions
   {
      public static void HasCount(this IEnumerable collection, int count) =>
         collection.Should().HaveCount(count);
   }
}
