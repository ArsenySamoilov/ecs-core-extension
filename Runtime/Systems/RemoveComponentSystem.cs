namespace SemsamECS.Core.Extension
{
    public sealed class RemoveComponentSystem<TComponent> : ISystem, IExecuteSystem where TComponent : struct
    {
        private readonly IPool<TComponent> _pool;

        public RemoveComponentSystem(IWorld world)
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