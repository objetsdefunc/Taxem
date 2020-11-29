namespace DefiniteAssertions
{
   using System;
   using static FluentAssertions.FluentActions;

   public static class DefiniteActions
   {
      public static Action Calling(Action call) => Invoking(call);
   }
}
