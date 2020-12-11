namespace JPI
{
   using System;

   public sealed class Disposable<T> : IDisposing<T>
      where T : IDisposable
   {
      private readonly ILazy<T> disposableFactory;

      internal Disposable(Func<T> disposable) =>
         disposableFactory = new CovariantLazy<T>(() => disposable());

      public TResult Use<TResult>(Func<T, TResult> use)
      {
         if (use is null)
         {
            throw new ArgumentNullException(nameof(use));
         }

         using (var disposable = disposableFactory.Value)
         {
            return use(disposable);
         }
      }

      public IDisposable<T> UseAsIDisposable() => new DisposableValue<T>(disposableFactory);
   }
}
