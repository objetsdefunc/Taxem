﻿namespace Taxem
{
   public sealed class Transaction
   {
      private readonly string line;

      public Transaction(string line) => this.line = line;

      internal string Text() => line.Split(',')[5] + " " + line.Split(',')[6];
   }
}
