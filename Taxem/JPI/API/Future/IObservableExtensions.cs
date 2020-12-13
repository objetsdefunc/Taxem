namespace JPI
{
   using System;

   public static class IObservableExtensions
   {
      public static Future<T> ToFuture<T>(this IObservable<T> observable) =>
         new Future<T>(observable);
   }
}
