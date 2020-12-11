namespace JPI
{
   using System;

   public interface IDisposable<out T> : IDisposable
   {
      T Value { get; }
   }
}
