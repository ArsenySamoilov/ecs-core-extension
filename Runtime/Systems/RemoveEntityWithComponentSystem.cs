namespace SemsamECS.Core.Extension
{
    public sealed class RemoveEntityWithComponentSystem<TComponent> : ISystem, IInitializeSystem, IExecuteSystem where TComponent : struct
    {
        private IEntities _entities;
        private IPool<TComponent> _pool;

        public void Initialize(IWorld world)
        {
            _entities = world.Entities;
            _pool = world.Pools.Get<TComponent>();
        }

        public void Execute()
        {
            var entities = _pool.GetEntities();
            for (var i = entities.Length - 1; i > -1; --i)
                _entities.Remove(entities[i]);
        }
    }
}