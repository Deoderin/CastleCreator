using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class ProjectileMono : MonoBehaviour
    {
        public GameObject projectile;
        public Transform spawnPosition;
        
        public class ProjectileBaker : Baker<ProjectileMono>
        {
            public override void Bake(ProjectileMono authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new ProjectileProperties
                {
                    spawnPosition = authoring.spawnPosition.position,
                    projectile = GetEntity(authoring.projectile, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}