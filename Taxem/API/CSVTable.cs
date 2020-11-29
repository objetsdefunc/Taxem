namespace Taxem
{
   using System;
   using System.Threading.Tasks;

   public interface CSVTable : IDisposable
   {
      Task<Header> Header();

      IObservable<string> Rows();
   }
}
