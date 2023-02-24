namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An interface of a group builder.
    /// </summary>
    public interface IGroupBuilder
    {
        /// <summary>
        /// Includes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of included component.</typeparam>
        IGroupBuilder Include<TComponent>() where TComponent : struct;

        /// <summary>
        /// Excludes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of excluded component.</typeparam>
        IGroupBuilder Exclude<TComponent>() where TComponent : struct;

        /// <summary>
        /// Returns a group with the matching set of components.
        /// </summary>
        IGroup Complete();
    }
}