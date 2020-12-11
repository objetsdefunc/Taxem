namespace JPI
{
   using System;

   public static class IObservableExtensions
   {
      internal static Future<T> ToFuture<T>(this IObservable<T> observable) =>
         new Future<T>(observable);
   }
}
