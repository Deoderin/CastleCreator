using Components;
using Unity.Burst;
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
            foreach (var allEntity in SystemAPI.Query<RefRW<PhysicsVelocity>>().WithAll<BallSpawnedTag>())
            {
                allEntity.ValueRW.Linear = new float3(-4,1,25);
                //state.EntityManager.RemoveComponent<BallSpawnedTag>(allEntity); use ecb
            }
        }
    }
}