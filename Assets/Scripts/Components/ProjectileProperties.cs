using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ProjectileProperties : IComponentData
    {
        public float3 SpawnPosition;
        public Entity Projectile;
    }

    public struct BallSpawnedTag : IComponentData { }
}