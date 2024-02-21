using Components;
using Unity.Entities;
using UnityEngine;

namespace Mono
{
    public class ProjectileMono : MonoBehaviour
    {
        public GameObject projectile;

        public class ProjectileBaker : Baker<ProjectileMono>
        {
            public override void Bake(ProjectileMono authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);

                AddComponent(entity,new ProjectileProperties
                {
                    spawnPosition = CameraSingleton.Instance.transform.position,
                    projectile = GetEntity(authoring.projectile, TransformUsageFlags.Dynamic)
                });
            }
        }
    }
}