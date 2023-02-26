namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a group.
    /// </summary>
    public static class GroupExtension
    {
        /// <summary>
        /// Tries to return an index of the entity in the entity span returned by <see cref="IGroup.GetEntities"/>.
        /// </summary>
        /// <returns>True if the index of entity has returned successfully, false elsewhere.</returns>
        public static bool TryGetEntityIndex(this IGroup group, int entity, out int index)
        {
            var isSuccessful = group.Have(entity);
            index = isSuccessful ? group.GetEntityIndex(entity) : -1;
            return isSuccessful;
        }
    }
}