namespace JPI
{
   using System.IO;

   public sealed class FilePath
   {
      internal FilePath(Text path) =>
         Path = new FileInfo(path.AsPrimitive).Length == 0
            ? throw new InvalidDataException("The file is empty.")
            : path;

      public Text Path { get; }

      public static FilePath ThatExists(a<Text> path) => new FilePath(path.NotNull);
   }
}
