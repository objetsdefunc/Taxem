namespace JPI
{
   using System;

   public static class LazyExtensions
   {
      public static TValue EnsuredBeforeReturning<TValue, TLazy>(this Lazy<TLazy> lazy, TValue value)
      {
         _ = lazy.Value;
         return value;
      }
   }
}
