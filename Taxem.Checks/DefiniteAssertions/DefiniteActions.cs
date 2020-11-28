namespace DefiniteAssertions
{
   using System;

   public static class DefiniteActions
   {
      public static Call Calling(Action call) => new Call(call);
   }
}
