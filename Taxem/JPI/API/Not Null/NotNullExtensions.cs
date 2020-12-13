namespace JPI
{
   using System.Collections.Generic;

   public static class NotNullExtensions
   {
      public static T NotNull<T>(this T @this)
         where T : class => new a<T>(@this).NotNull;
   }
}
