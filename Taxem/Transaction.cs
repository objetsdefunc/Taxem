namespace Taxem
{
   internal sealed class Transaction
   {
      private string line;

      public Transaction(string line) => this.line = line;

      internal string Text() => line.Split(',')[5] + " " + line.Split(',')[6];
   }
}