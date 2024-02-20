using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ProjectileProperties : IComponentData
    {
        public float3 spawnPosition;
        public Entity projectile;
    }

    public struct BallSpawnedTag : IComponentData { }
}