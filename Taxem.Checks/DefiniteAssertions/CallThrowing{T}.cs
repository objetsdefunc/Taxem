﻿namespace DefiniteAssertions
{
   using System;

   public class CallThrowing<T>
      where T : Exception
   {
      private readonly Call call;

      internal CallThrowing(Call call) => this.call = call;

      internal void WithMessage(string message) => call.ThrowsWithMessage<T>(message);
   }
}
