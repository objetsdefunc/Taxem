namespace DefiniteAssertions
{
   using System;
   using FluentAssertions;
   using FluentAssertions.Specialized;

   public static class TypeAssertions
   {
      public static void Is<T>(this T actual, T expected) =>
         actual.Should().Be(expected);

      public static ExceptionAssertions<TException> Throws<TException>(this Action @action)
         where TException : Exception =>
         action.Should().Throw<TException>();

      public static void DoesNotThrow(this Action @action) =>
         action.Should().NotThrow();
   }
}
