namespace SemsamECS.Core.Extension
{
    /// <summary>
    /// An extension of a group container.
    /// </summary>
    public static class GroupsExtension
    {
        /// <summary>
        /// Begins building a group.
        /// </summary>
        /// <typeparam name="TComponent">Any included component in the group.</typeparam>
        public static IGroupBuilder Build<TComponent>(this IGroups groupContainer, in GroupConfig? groupConfig = null) where TComponent : struct
        {
            IGroupBuilder groupBuilder = new GroupConstructor(groupContainer, ((Groups)groupContainer).PoolContainer, groupConfig);
            groupBuilder.Include<TComponent>();
            return groupBuilder;
        }

        /// <summary>
        /// Begins ruining a group.
        /// </summary>
        /// <typeparam name="TComponent">Any included component in the group.</typeparam>
        public static IGroupRuiner Ruin<TComponent>(this IGroups groupContainer, in GroupConfig? groupConfig = null) where TComponent : struct
        {
            IGroupRuiner groupRuiner = new GroupConstructor(groupContainer, null, groupConfig);
            groupRuiner.Include<TComponent>();
            return groupRuiner;
        }
    }
}