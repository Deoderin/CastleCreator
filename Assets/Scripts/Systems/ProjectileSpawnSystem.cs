using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct ProjectileSpawnSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if(Input.GetButtonDown("Jump"))
            {
                var ecb = new EntityCommandBuffer(Allocator.Temp);
                
                foreach (RefRW<ProjectileProperties> properties in SystemAPI.Query<RefRW<ProjectileProperties>>())
                {
                    Entity projectile = state.EntityManager.Instantiate(properties.ValueRO.Projectile);
                    state.EntityManager.SetComponentData(projectile, LocalTransform.FromPosition(properties.ValueRO.SpawnPosition));
                    ecb.AddComponent(projectile, new BallSpawnedTag());
                }
                
                ecb.Playback(state.EntityManager);
            }
        }
    }
}