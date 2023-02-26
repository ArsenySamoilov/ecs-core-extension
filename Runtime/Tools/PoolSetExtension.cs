namespace SemsamECS.Core.Extension
{
    public static class PoolSetExtension
    {
        /// <summary>
        /// Includes the pool.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static void IncludeSafe<TComponent>(this PoolSet poolSet) where TComponent : struct
        {
            poolSet.PoolContainer.GetSafe<TComponent>();
            poolSet.Include<TComponent>();
        }

        /// <summary>
        /// Excludes the pool.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static void ExcludeSafe<TComponent>(this PoolSet poolSet) where TComponent : struct
        {
            poolSet.PoolContainer.GetSafe<TComponent>();
            poolSet.Include<TComponent>();
        }
    }
}