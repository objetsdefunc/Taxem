namespace DefiniteAssertions
{
   using System;

   public static class DefiniteActions
   {
      public static AssertableCall Calling(Action call) => new AssertableCall(call);
   }
}
