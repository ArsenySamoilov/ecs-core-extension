namespace SemsamECS.Core.Extension
{
    public sealed class RemoveComponentSystem<TComponent> : ISystem, IInitializeSystem, IExecuteSystem where TComponent : struct
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