namespace JPI
{
   using System;

   public static class IDisposableExtensions
   {
      public static IDisposing<T> ToAutoDisposing<T>(this T @this, Func<T> factory)
         where T : class, IDisposable
      {
         _ = @this.NotNull();
         return new Disposable<T>(factory);
      }
   }
}
