namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of an entity container.
    /// </summary>
    public static class EntitiesExtension
    {
        /// <summary>
        /// Boxes the entity.
        /// Doesn't check the presence of the entity.
        /// </summary>
        public static BoxedEntity Box(this IEntities entityContainer, int entity)
            => new(entityContainer, entity);

        /// <summary>
        /// Boxes the entity.
        /// </summary>
        /// <returns>True if the entity has boxed successfully, false elsewhere.</returns>
        public static bool TryBox(this IEntities entityContainer, int entity, out BoxedEntity boxedEntity)
        {
            var isSuccessful = entityContainer.Have(entity);
            boxedEntity = isSuccessful ? new BoxedEntity(entityContainer, entity) : null;
            return isSuccessful;
        }

        /// <summary>
        /// Tries to unbox the boxed entity.
        /// </summary>
        /// <returns>True if the boxed entity has unboxed successfully, false elsewhere.</returns>
        public static bool TryUnbox(this IEntities entityContainer, BoxedEntity boxedEntity, out int entity)
        {
            return boxedEntity.TryUnbox(entityContainer, out entity);
        }
    }
}