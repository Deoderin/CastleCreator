using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;
using UnityEngine;

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
                foreach (var prop in SystemAPI.Query<RefRW<LocalTransform>>().WithAll<AimingProperties>())
                {
                    allEntity.Item1.ValueRW.Linear = prop.ValueRO.Forward() * 100;
                    ecb.RemoveComponent<BallSpawnedTag>(allEntity.Item2);
                }
            }

            ecb.Playback(state.EntityManager);
        }
    }
}