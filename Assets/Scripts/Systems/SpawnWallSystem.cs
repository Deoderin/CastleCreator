using Components;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnWallSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<WallProperties>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            var wallEntity = SystemAPI.GetSingletonEntity<WallProperties>();
            var wall = SystemAPI.GetAspect<WallAspect>(wallEntity);
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            for (int x = 0; x < wall.NumberWallToSpawn.x; x++)
            {
                for (int y = 0; y < wall.NumberWallToSpawn.y; y++)
                {
                    for (int z = 0; z < wall.NumberWallToSpawn.z; z++)
                    {
                        var block = ecb.Instantiate(wall.BlockPrefab);
                        var blockTransform = TransformExtenstion.GetBollTransform(new int3(x,y,z));
                        ecb.SetComponent(block, blockTransform);
                    }
                }
            }
            
            ecb.Playback(state.EntityManager);
        }

        [BurstCompile]
        private void CreateWallStructure()
        {
            
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
            
        }
    }
}