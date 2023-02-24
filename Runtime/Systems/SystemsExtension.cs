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
        public static ISystems Add<TSystem>(this ISystems systems) where TSystem : class, ISystem, new()
        {
            return systems.Add(new TSystem());
        }
    }
}