namespace JPI
{
   using System.Collections.Generic;

   public static class ClassExtensions
   {
      public static IReadOnlyList<T> InList<T>(this T @this)
         where T : class => new List<T>() { @this };
   }
}
