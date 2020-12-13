namespace JPI
{
#pragma warning disable CA1815 // Override equals and operator equals on value types
#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA2225 // Operator overloads have named alternates

   /// <summary>
   /// A type-safe way to "ensure" that a reference type is not null.
   /// All public interfaces should accept types in this way.
   /// Or... just under the interface?
   /// </summary>
   /// <typeparam name="T">Any reference type.</typeparam>
   public struct a<T>
      where T : class
   {
      internal a(T @object) =>
         NotNull = @object ?? throw new System.ArgumentNullException(nameof(@object));

      public T NotNull { get; }

      public static implicit operator a<T>(T @object) => new a<T>(@object);
   }

#pragma warning restore CA2225 // Operator overloads have named alternates
#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA1815 // Override equals and operator equals on value types
}
