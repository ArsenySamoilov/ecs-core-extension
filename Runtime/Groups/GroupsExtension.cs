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
        public static IGroupBuilder Build<TComponent>(this IGroups groups, in GroupConfig? groupConfig = null) where TComponent : struct
        {
            return ((IGroupBuilder)new GroupConstructor((Groups)groups, ((Groups)groups).PoolContainer, groupConfig)).Include<TComponent>();
        }

        /// <summary>
        /// Begins ruining a group.
        /// </summary>
        /// <typeparam name="TComponent">Any included component in the group.</typeparam>
        public static IGroupRuiner Ruin<TComponent>(this Groups groups, in GroupConfig? groupConfig = null) where TComponent : struct
        {
            return ((IGroupRuiner)new GroupConstructor(groups, null, groupConfig)).Include<TComponent>();
        }
    }
}