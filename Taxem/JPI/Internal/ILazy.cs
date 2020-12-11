namespace JPI
{
   public interface ILazy<out T>
   {
      T Value { get; }
   }
}
