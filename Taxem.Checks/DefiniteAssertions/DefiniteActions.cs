namespace DefiniteAssertions
{
   using System;
   using System.Reactive.Linq;
   using static FluentAssertions.FluentActions;

   public static class DefiniteActions
   {
      public static Action Calling(Action call) => Invoking(call);

      public static Action SubscribingTo<T>(Func<IObservable<T>> call)
      {
         return Enumerating(() => call().ToEnumerable());
      }
   }
}
