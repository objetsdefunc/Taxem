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

#pragma warning disable CA1062 // Validate arguments of public methods
      public static FilePath ThatExists(Text path) => new FilePath(path);
#pragma warning restore CA1062 // Validate arguments of public methods
   }
}
