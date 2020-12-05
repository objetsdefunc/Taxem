namespace Taxem
{
   using System;

   internal static class LazyExtensions
   {
      internal static T EnsuredBeforeReturning<T, TLazy>(this Lazy<TLazy> lazy, T value)
      {
         _ = lazy.Value;
         return value;
      }
   }
}
