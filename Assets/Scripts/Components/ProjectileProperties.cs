using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct ProjectileProperties : IComponentData
    {
        public float3 SpawnPosition;
        public float3 Direction;
        public Entity Projectile;
    }
}