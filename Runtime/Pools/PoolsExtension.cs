namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a pool container.
    /// </summary>
    public static class PoolsExtension
    {
        /// <summary>
        /// Creates a pool.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static IPool<TComponent> CreateSafe<TComponent>(this IPools poolContainer, in PoolConfig? poolConfig = null) where TComponent : struct
            => poolContainer.Have<TComponent>() ? poolContainer.Get<TComponent>() : poolContainer.Create<TComponent>(poolConfig);

        /// <summary>
        /// Creates a pool and returns itself.
        /// Doesn't check the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static IPools Add<TComponent>(this IPools poolContainer, in PoolConfig? poolConfig = null) where TComponent : struct
        {
            poolContainer.Create<TComponent>(poolConfig);
            return poolContainer;
        }

        /// <summary>
        /// Creates a pool and returns itself.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static IPools AddSafe<TComponent>(this IPools poolContainer, in PoolConfig? poolConfig = null) where TComponent : struct
        {
            if (poolContainer.Have<TComponent>())
                poolContainer.Create<TComponent>(poolConfig);
            return poolContainer;
        }

        /// <summary>
        /// Removes the pool.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static void Remove<TComponent>(this IPools poolContainer) where TComponent : struct
        {
            if (poolContainer.Have<TComponent>())
                poolContainer.Remove<TComponent>();
        }

        /// <summary>
        /// Removes the pool and returns itself.
        /// Doesn't check the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static Pools Delete<TComponent>(this Pools poolContainer) where TComponent : struct
        {
            poolContainer.Remove<TComponent>();
            return poolContainer;
        }

        /// <summary>
        /// Removes the pool and returns itself.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static Pools DeleteSafe<TComponent>(this Pools poolContainer) where TComponent : struct
        {
            if (poolContainer.Have<TComponent>())
                poolContainer.Remove<TComponent>();
            return poolContainer;
        }

        /// <summary>
        /// Returns the pool.
        /// Checks the presence of the pool.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained in the pool.</typeparam>
        public static IPool<TComponent> GetSafe<TComponent>(this IPools poolContainer) where TComponent : struct
            => poolContainer.Have<TComponent>() ? poolContainer.Get<TComponent>() : poolContainer.Create<TComponent>();
    }
}