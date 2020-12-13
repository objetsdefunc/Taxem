namespace JPI
{
   using System;
   using System.Collections.Generic;

   public static class ClassExtensions
   {
      public static T NotNull<T>(this T @this)
         where T : class => new a<T>(@this).NotNull;

      public static IReadOnlyList<T> InList<T>(this T @this)
         where T : class => new List<T>() { @this };
   }
}
