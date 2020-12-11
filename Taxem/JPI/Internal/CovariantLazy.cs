namespace JPI
{
   using System;

   internal class CovariantLazy<T> : ILazy<T>
   {
      private readonly Lazy<T> lazy;

      public CovariantLazy(Lazy<T> lazy) => this.lazy = lazy;

      public CovariantLazy(Func<T> lazy)
         : this(new Lazy<T>(lazy))
      {
      }

      public T Value => lazy.Value;
   }
}
