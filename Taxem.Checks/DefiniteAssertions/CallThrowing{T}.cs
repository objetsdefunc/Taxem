namespace DefiniteAssertions
{
   using System;

   public class CallThrowing<T>
      where T : Exception
   {
      private readonly AssertableCall call;

      internal CallThrowing(AssertableCall call) => this.call = call;

      internal void WithMessage(string message) => call.ThrowsWithMessage<T>(message);
   }
}
