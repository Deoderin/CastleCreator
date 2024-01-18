using Components;
using Unity.Entities;

namespace Mono
{
    public class ProjectileBaker : Baker<ProjectileMono>
    {
        public override void Bake(ProjectileMono authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity,new ProjectileProperties
            {
                SpawnPosition = authoring.SpawnPosition,
                Direction = authoring.Direction,
                Projectile = GetEntity(authoring.Projectile, TransformUsageFlags.Dynamic)
            });
        }
    }
}