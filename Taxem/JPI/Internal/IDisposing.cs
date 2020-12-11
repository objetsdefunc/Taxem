namespace JPI
{
   using System;

   public interface IDisposing<out T>
      where T : IDisposable
   {
      TResult Use<TResult>(Func<T, TResult> use);

      IDisposable<T> UseAsIDisposable();
   }
}
