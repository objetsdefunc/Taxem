namespace Taxem
{
   using System;

   internal static class IObservableExtensions
   {
      internal static Future<T> ToFuture<T>(this IObservable<T> observable) =>
         new Future<T>(observable);
   }
}
