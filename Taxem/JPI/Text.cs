namespace JPI
{
   public sealed class Text
   {
      public Text(a<string> text)
      {
         var safeText = text.NotNull;

         AsPrimitive = string.IsNullOrWhiteSpace(safeText)
            ? throw new System.ArgumentException(
               $"'{nameof(text)}' cannot be null or whitespace", nameof(text))
            : safeText;
      }

      public string AsPrimitive { get; }
   }
}
