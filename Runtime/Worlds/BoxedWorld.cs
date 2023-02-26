namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// A box for safe storage of the world.
    /// Holds world's object and index.
    /// </summary>
    public sealed class BoxedWorld
    {
        private IWorlds _worldContainer;
        private IWorld _world;
        private bool _isAlive;

        public BoxedWorld(IWorlds worldContainer, IWorld world)
        {
            _worldContainer = worldContainer;
            _world = world;
            _isAlive = true;
            world.Disposed += OnWorldDisposed;
            WorldsInstance.Disposed += OnWorldsDisposed;
        }

        /// <summary>
        /// Tries to unbox the boxed world.
        /// </summary>
        /// <returns>True if the boxed world has unboxed successfully, false elsewhere.</returns>
        public bool TryUnbox(out IWorld world)
        {
            var worldId = _world.Id;
            var isSuccessful = _isAlive && _worldContainer.Have(worldId) && _worldContainer.Get(worldId) == _world;
            world = isSuccessful ? _world : null;
            return isSuccessful;
        }

        private void OnWorldDisposed(IWorld world)
        {
            _isAlive = false;
            world.Disposed -= OnWorldDisposed;
            WorldsInstance.Disposed -= OnWorldsDisposed;
            _world = null;
            _worldContainer = null;
        }

        private void OnWorldsDisposed(IWorlds worldContainer)
        {
            _isAlive = false;
            _world.Disposed -= OnWorldDisposed;
            WorldsInstance.Disposed -= OnWorldsDisposed;
            _world = null;
            _worldContainer = null;
        }
    }
}