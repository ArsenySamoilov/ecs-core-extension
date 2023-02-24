namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a pool container.
    /// </summary>
    public static class PoolsExtension
    {
        /// <summary>
        /// Creates a pool and returns itself.
        /// Doesn't check the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static IPools Add<TComponent>(this IPools pools, in PoolConfig? poolConfig = null) where TComponent : struct
        {
            pools.Create<TComponent>(poolConfig);
            return pools;
        }

        /// <summary>
        /// Removes the pool and returns itself.
        /// Doesn't check the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static Pools Delete<TComponent>(this Pools pools) where TComponent : struct
        {
            pools.Remove<TComponent>();
            return pools;
        }
    }
}