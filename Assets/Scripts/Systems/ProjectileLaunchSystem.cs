using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;

namespace Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(ProjectileSpawnSystem))]
    public partial struct ProjectileLaunchSystem  : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer ecb = new EntityCommandBuffer(Allocator.Temp);

            foreach (var allEntity in SystemAPI.Query<RefRW<PhysicsVelocity>>().WithAll<BallSpawnedTag>().WithEntityAccess())
            {
                allEntity.Item1.ValueRW.Linear = new float3(-4,1,25);
                ecb.RemoveComponent<BallSpawnedTag>(allEntity.Item2);
            }

            ecb.Playback(state.EntityManager);
        }
    }
}