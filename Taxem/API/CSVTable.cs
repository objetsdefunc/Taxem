namespace Taxem
{
   using System;
   using System.IO;

   public sealed class CSVTable
   {
      private readonly Lazy<Header> header;

      public CSVTable(TextReader text)
      {
         _ = text ?? throw new ArgumentNullException(nameof(text));

         header = new Lazy<Header>(() => new Header(text.ReadLine()));
      }

      public Header Header() => header.Value;
   }
}
