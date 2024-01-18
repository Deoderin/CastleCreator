using Components;
using Mono;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

namespace Systems
{
    //[BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateAfter(typeof(ProjectileSpawnSystem))]
    public partial struct ProjectileLaunchSystem  : ISystem
    {
        private EntityQuery _query;

        public void OnCreate(ref SystemState state)
        {
            _query = state.GetEntityQuery(ComponentType.ReadOnly<BallProperties>());
        }
        
        //[BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if(Input.touchCount > 0)
            {
                var physicsVelocityComponent = state.GetComponentLookup<PhysicsVelocity>();
                var components  = _query.ToComponentDataArray<BallProperties>(Allocator.TempJob);
                var ecb = new EntityCommandBuffer(Allocator.TempJob);
                
                for (int i = 0; i < components.Length; i++)
                {
                    if(components[i].IsShot) continue;

                    var entity = components[i].Ball;
                    if(!physicsVelocityComponent.HasComponent(entity)) continue;

                    var ballProperties = new PhysicsVelocity
                    {
                        Angular = float3.zero,
                        Linear = GetLaunchDirection() * 10
                    };
                    
                    ecb.SetComponent(entity, ballProperties);
                    
                    var updatedBallProperties = components[i];
                    updatedBallProperties.IsShot = true;
                    ecb.SetComponent(entity, updatedBallProperties);
                }

                components.Dispose();
                ecb.Playback(state.EntityManager);
                ecb.Dispose();
            }
        }

        //ToDo switch ray 
        private float3 GetLaunchDirection()
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 30));
            return touchPosition;
        }
    }    

    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct ProjectileSpawnSystem : ISystem
    {
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            if(Input.touchCount > 0)
            {
                var bollEntity = SystemAPI.GetSingletonEntity<ProjectileProperties>();
                var ballInfo = SystemAPI.GetAspect<ProjectileAspect>(bollEntity);
                var ecb = new EntityCommandBuffer(Allocator.Persistent);
            
                var projectile = ecb.Instantiate(ballInfo.BollPrefab);
                var blockTransform = TransformExtenstion.GetBollTransform(ballInfo.PositionToSpawn);

                var ballProperties = new BallProperties
                {
                    Ball = projectile,
                    IsShot = false
                };
                
                ecb.SetComponent(projectile, blockTransform);                
                ecb.AddComponent(projectile, ballProperties);
                ecb.Playback(state.EntityManager);
                ecb.Dispose();
            }
        }
    }

    public readonly partial struct BallAspect : IAspect
    {
        private readonly RefRW<BallProperties> _ballProperties;
        public readonly Entity Entity;
    }
    
    public struct BallProperties : IComponentData
    {
        public Entity Ball;
        public bool IsShot;
    }
}