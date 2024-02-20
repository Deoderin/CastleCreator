using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class ProjectileMono : MonoBehaviour
    {
        public Transform SpawnPosition;
        public GameObject Projectile;
        
        public class ProjectileBaker : Baker<ProjectileMono>
        {
            public override void Bake(ProjectileMono authoring)
            {
                var entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new ProjectileProperties
                {
                    SpawnPosition = authoring.SpawnPosition.position,
                    Projectile = GetEntity(authoring.Projectile, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}