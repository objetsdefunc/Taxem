namespace DefiniteAssertions
{
   using System;
   using FluentAssertions;

   public sealed class Call
   {
      private readonly Action call;

      public Call(Action call) => this.call = call;

      internal CallThrowing<T> Throws<T>()
         where T : Exception
            => new CallThrowing<T>(this);

      internal void ThrowsWithMessage<T>(string message)
         where T : Exception =>
            FluentActions.Invoking(call).Should().ThrowExactly<T>().WithMessage(message);
   }
}
