namespace Taxem
{
   using System.Collections.Generic;

   internal interface TransactionFile
   {
      IReadOnlyList<string> Transactions();
   }
}