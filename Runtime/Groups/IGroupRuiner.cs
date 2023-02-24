namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An interface of a group ruiner.
    /// </summary>
    public interface IGroupRuiner
    {
        /// <summary>
        /// Includes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of included component.</typeparam>
        IGroupRuiner Include<TComponent>() where TComponent : struct;

        /// <summary>
        /// Excludes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of excluded component.</typeparam>
        IGroupRuiner Exclude<TComponent>() where TComponent : struct;

        /// <summary>
        /// Removes the group with the matching set of components.
        /// </summary>
        Groups Complete();
    }
}