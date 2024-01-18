using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct WallProperties : IComponentData
    {
        public int3 FieldDimension;
        public Entity BlockPrefab;
    }
}