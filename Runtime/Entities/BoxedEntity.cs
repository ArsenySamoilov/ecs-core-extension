namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// A box for safe storage of an entity.
    /// </summary>
    public sealed class BoxedEntity
    {
        private readonly IEntities _entityContainer;
        private readonly int _entity;
        private bool _isAlive;

        public BoxedEntity(IEntities entityContainer, int entity)
        {
            _entityContainer = entityContainer;
            _entity = entity;
            _isAlive = true;
            entityContainer.Removed += OnRemoved;
            entityContainer.Disposed += OnDisposed;
        }

        /// <summary>
        /// Tries to unbox the boxed entity.
        /// </summary>
        /// <returns>True if boxed entity has unboxed successfully, false elsewhere.</returns>
        public bool TryUnbox(out int entity)
        {
            var isSuccessful = _isAlive;
            entity = isSuccessful ? _entity : -1;
            return isSuccessful;
        }

        /// <summary>
        /// Tries to unbox the boxed entity.
        /// </summary>
        /// <returns>True if boxed entity has unboxed successfully, false elsewhere.</returns>
        public bool TryUnbox(IEntities entityContainer, out int entity)
        {
            var isSuccessful = _isAlive && _entityContainer == entityContainer;
            entity = isSuccessful ? _entity : -1;
            return isSuccessful;
        }

        private void OnRemoved(int entity)
        {
            if (entity != _entity)
                return;
            _isAlive = false;
            _entityContainer.Removed -= OnRemoved;
            _entityContainer.Disposed -= OnDisposed;
        }

        private void OnDisposed(IEntities entities)
        {
            _isAlive = false;
            entities.Removed -= OnRemoved;
            entities.Disposed -= OnDisposed;
        }
    }
}