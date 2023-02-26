namespace SemsamECS.Core.Extension
{
    public static class WorldsExtension
    {
        /// <summary>
        /// Boxes the world.
        /// Doesn't check the presence of the world.
        /// </summary>
        public static BoxedWorld Box(this IWorlds worldContainer, IWorld world)
            => new(worldContainer, world);

        /// <summary>
        /// Tries to box the world.
        /// </summary>
        /// <returns>True if the world has boxed successfully, false elsewhere.</returns>
        public static bool TryBox(this IWorlds worldContainer, IWorld world, out BoxedWorld boxedWorld)
        {
            var worldId = world.Id;
            var isSuccessful = worldContainer.Have(worldId) && worldContainer.Get(worldId) == world;
            boxedWorld = isSuccessful ? new BoxedWorld(worldContainer, world) : null;
            return isSuccessful;
        }
    }
}