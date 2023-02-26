namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a system container.
    /// </summary>
    public static class SystemsExtension
    {
        /// <summary>
        /// Adds a system and returns itself.
        /// </summary>
        /// <typeparam name="TSystem">The type of the system.</typeparam>
        public static ISystems Add<TSystem>(this ISystems systemContainer) where TSystem : class, ISystem, new()
            => systemContainer.Add(new TSystem());

        /// <summary>
        /// Removes the system at the index.
        /// Checks the presence of the system.
        /// </summary>
        public static void Remove(this ISystems systemContainer, int index)
        {
            if (index < systemContainer.GetSystems().Length)
                systemContainer.Remove(index);
        }
    }
}