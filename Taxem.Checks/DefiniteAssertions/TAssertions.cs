namespace DefiniteAssertions
{
   using FluentAssertions;

   public static class TAssertions
   {
      public static void Is<T>(this T actual, T expected) =>
         actual.Should().Be(expected);
   }
}
