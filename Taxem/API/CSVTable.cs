﻿namespace Taxem
{
   using System;

   public interface CSVTable : IDisposable
   {
      Future<Header> Header();

      IObservable<Row> Rows();
   }
}
