namespace JPI
{
   using System;

   public static class DisposableExtensions
   {
#pragma warning disable IDE0060 // Remove unused parameter
      internal static IDisposing<T> ToAutoDisposing<T>(this T @this, Func<T> factory)
#pragma warning restore IDE0060 // Remove unused parameter
         where T : IDisposable => new Disposable<T>(factory);
   }
}
