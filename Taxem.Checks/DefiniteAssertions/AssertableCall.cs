namespace DefiniteAssertions
{
   using System;
   using FluentAssertions;
   using static FluentAssertions.FluentActions;

   public sealed class AssertableCall
   {
      private readonly Action call;

      public AssertableCall(Action call) => this.call = call;

      internal CallThrowing<T> Throws<T>()
         where T : Exception =>
            new CallThrowing<T>(this);

      internal CallThrowingAggregateOf<T> ThrowsAnAggregateWith<T>()
         where T : Exception =>
            new CallThrowingAggregateOf<T>(this);

      internal void ThrowsWithMessage<T>(string message)
         where T : Exception =>
            Invoking(call).Should().ThrowExactly<T>().WithMessage(message);

      internal void ThrowsAggregateWithMessage<T>(string message)
         where T : Exception =>
            Invoking(call).Should()
               .ThrowExactly<AggregateException>().WithInnerException<T>().WithMessage(message);

      internal void DoesNotThrow() =>
         Invoking(call).Should().NotThrow();
   }
}
