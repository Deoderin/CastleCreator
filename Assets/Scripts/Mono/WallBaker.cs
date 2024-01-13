using Components;
using Unity.Entities;

namespace Mono
{
    public class WallBaker : Baker<WallMono>
    {
        public override void Bake(WallMono authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,new WallProperties
            {
                FieldDimension = authoring.FieldDimension,
                BlockPrefab = GetEntity(authoring.BlockPrefab, TransformUsageFlags.Dynamic)
            });
        }
    }
}