namespace JPI
{
   using System;

   public static class Disposable
   {
      public static Disposable<T> Of<T>(Func<T> factory)
         where T : IDisposable => new Disposable<T>(factory);
   }
}
