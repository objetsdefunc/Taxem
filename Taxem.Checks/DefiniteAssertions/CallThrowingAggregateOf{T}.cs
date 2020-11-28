namespace DefiniteAssertions
{
   using System;

   public class CallThrowingAggregateOf<T>
      where T : Exception
   {
      private readonly AssertableCall call;

      internal CallThrowingAggregateOf(AssertableCall call) => this.call = call;

      internal void WithMessage(string message) => call.ThrowsAggregateWithMessage<T>(message);
   }
}
