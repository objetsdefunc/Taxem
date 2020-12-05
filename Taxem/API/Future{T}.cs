﻿namespace Taxem
{
   using System;
   using System.Reactive.Linq;
   using System.Runtime.CompilerServices;

   public sealed class Future<T> : INotifyCompletion
   {
      private readonly IObservable<T> observable;
      private readonly IDisposable subscription;

      internal Future(IObservable<T> observable)
      {
         this.observable = observable.SingleAsync();

         subscription = this.observable.Subscribe(
            _ => { },
            error => { },
            () => IsCompleted = true);
      }

      public bool IsCompleted { get; private set; }

      public T GetResult() => Result();

      public T Result()
      {
         try
         {
            return observable.Wait();
         }
         finally
         {
            subscription.Dispose();
         }
      }

      public Future<T> GetAwaiter() => this;

      public void OnCompleted(Action continuation)
      {
         if (continuation is null)
         {
            throw new ArgumentNullException(nameof(continuation));
         }

         continuation();
      }
   }
}
