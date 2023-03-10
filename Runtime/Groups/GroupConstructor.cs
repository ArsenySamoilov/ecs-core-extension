namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// A group constructor.
    /// Represents a builder and a ruiner.
    /// </summary>
    public sealed class GroupConstructor : IGroupBuilder, IGroupRuiner
    {
        private readonly IGroups _groupContainer;
        private readonly GroupConfig? _groupConfig;
        private readonly PoolSet _poolSet;
        private readonly TypeSet _typeSet;

        public GroupConstructor(IGroups groupContainer, Pools poolContainer, in GroupConfig? groupConfig = null)
        {
            _groupContainer = groupContainer;
            _groupConfig = groupConfig;
            _poolSet = new PoolSet(poolContainer, groupConfig);
            _typeSet = new TypeSet(groupConfig);
        }

        /// <summary>
        /// Includes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of included component.</typeparam>
        IGroupBuilder IGroupBuilder.Include<TComponent>() where TComponent : struct
        {
            _poolSet.IncludeSafe<TComponent>();
            _typeSet.Include<TComponent>();
            return this;
        }

        /// <summary>
        /// Includes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of included component.</typeparam>
        IGroupRuiner IGroupRuiner.Include<TComponent>() where TComponent : struct
        {
            _typeSet.Include<TComponent>();
            return this;
        }

        /// <summary>
        /// Excludes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of excluded component.</typeparam>
        IGroupBuilder IGroupBuilder.Exclude<TComponent>() where TComponent : struct
        {
            _poolSet.ExcludeSafe<TComponent>();
            _typeSet.Exclude<TComponent>();
            return this;
        }

        /// <summary>
        /// Excludes all the entities with a component.
        /// </summary>
        /// <typeparam name="TComponent">The type of excluded component.</typeparam>
        IGroupRuiner IGroupRuiner.Exclude<TComponent>() where TComponent : struct
        {
            _typeSet.Exclude<TComponent>();
            return this;
        }

        /// <summary>
        /// Returns a group with the matching set of components.
        /// </summary>
        IGroup IGroupBuilder.Complete()
            => _groupContainer.Get(_typeSet, _poolSet, _groupConfig);

        /// <summary>
        /// Removes the group with the matching set of components.
        /// </summary>
        IGroups IGroupRuiner.Complete()
        {
            _groupContainer.Remove(_typeSet);
            return _groupContainer;
        }
    }
}