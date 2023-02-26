namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// A system that removes all the components.
    /// </summary>
    /// <typeparam name="TComponent">The type of the component.</typeparam>
    public sealed class ComponentRemovalSystem<TComponent> : ISystem, IInitializeSystem, IExecuteSystem where TComponent : struct
    {
        private IPool<TComponent> _pool;

        public void Initialize(IWorld world)
        {
            _pool = world.Pools.Get<TComponent>();
        }

        public void Execute()
        {
            var entities = _pool.GetEntities();
            for (var i = entities.Length - 1; i > -1; --i)
                _pool.Remove(entities[i]);
        }
    }
}