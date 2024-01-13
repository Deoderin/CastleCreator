using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Components
{
    public readonly partial struct WallAspect : IAspect
    {
        private readonly RefRO<WallProperties> _wallProperties;
        public readonly Entity Entity;
        public int2 NumberWallToSpawn => _wallProperties.ValueRO.FieldDimension;
        public Entity BlockPrefab => _wallProperties.ValueRO.BlockPrefab;

        public LocalTransform GetBlockTransform(int2 position)
        {
            return new LocalTransform()
            {
                Position = new float3(position.x, position.y, 0), Rotation = quaternion.identity, Scale = 1,
            };
        }
    }
}