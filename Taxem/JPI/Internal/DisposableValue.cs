namespace JPI
{
   using System;

   internal sealed class DisposableValue<T> : IDisposable<T>
      where T : IDisposable
   {
      private readonly ILazy<T> disposable;

      public DisposableValue(ILazy<T> disposable) => this.disposable = disposable;

      // Lazily evaluated
      public T Value => disposable.Value;

      public void Dispose() => Value.Dispose();
   }
}
