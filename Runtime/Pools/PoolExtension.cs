namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a pool.
    /// </summary>
    public static class PoolExtension
    {
        /// <summary>
        /// Creates a component for the entity.
        /// Checks the presence of the component.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained.</typeparam>
        public static ref TComponent CreateSafe<TComponent>(this IPool<TComponent> pool, int entity, TComponent sourceComponent = default)
            where TComponent : struct
        {
            if (!pool.Have(entity))
                return ref pool.Create(entity, sourceComponent);
            ref var component = ref pool.Get(entity);
            component = sourceComponent;
            return ref component;
        }

        /// <summary>
        /// Removes the component from the entity.
        /// Checks the presence of the component.
        /// </summary>
        /// <typeparam name="TComponent">The type of components contained.</typeparam>
        public static void RemoveSafe<TComponent>(this IPool<TComponent> pool, int entity) where TComponent : struct
        {
            if (pool.Have(entity))
                pool.Remove(entity);
        }

        /// <summary>
        /// Returns the component for the entity.
        /// Checks the presence of the component.
        /// </summary>
        public static ref TComponent GetSafe<TComponent>(this IPool<TComponent> pool, int entity) where TComponent : struct
        {
            if (pool.Have(entity))
                return ref pool.Get(entity);
            return ref pool.Create(entity);
        }
    }
}