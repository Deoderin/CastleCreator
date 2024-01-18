using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Components
{
    public readonly partial struct WallAspect : IAspect
    {
        private readonly RefRO<WallProperties> _wallProperties;
        public readonly Entity Entity;
        public int3 NumberWallToSpawn => _wallProperties.ValueRO.FieldDimension;
        public Entity BlockPrefab => _wallProperties.ValueRO.BlockPrefab;
    }
    
    public readonly partial struct ProjectileAspect : IAspect
    {
        private readonly RefRO<ProjectileProperties> _projectileProperties;
        public readonly Entity Entity;
        public float3 PositionToSpawn => _projectileProperties.ValueRO.SpawnPosition;
        public float3 ShotDirection => _projectileProperties.ValueRO.Direction;
        public Entity BollPrefab => _projectileProperties.ValueRO.Projectile;
    }
}