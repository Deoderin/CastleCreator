using Components;
using Mono;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial class ProjectileSpawnSystem : SystemBase
    {
        private bool _isSpawn;
        
        [BurstCompile]
        protected override void OnUpdate()
        {
            if(_isSpawn)
            {
                var state = CheckedStateRef;
                EntityCommandBuffer ecb = new(Allocator.Temp);
                foreach (RefRW<ProjectileProperties> properties in SystemAPI.Query<RefRW<ProjectileProperties>>())
                {
                    Entity projectile = state.EntityManager.Instantiate(properties.ValueRO.projectile);
                    state.EntityManager.SetComponentData(projectile, LocalTransform.FromPosition(properties.ValueRO.spawnPosition));
                    ecb.AddComponent(projectile, new BallSpawnedTag());
                }

                _isSpawn = false;
                ecb.Playback(state.EntityManager);
            }
        }
        
        private void SpawnProjectileTrigger() => _isSpawn = true;
        protected override void OnCreate() => InputProvider.shoot += SpawnProjectileTrigger;
        protected override void OnDestroy() => InputProvider.shoot -= SpawnProjectileTrigger;
    }
}