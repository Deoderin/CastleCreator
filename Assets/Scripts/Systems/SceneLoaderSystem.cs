using Mono;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Scenes;
using UnityEngine;

namespace Systems
{
    //[RequireMatchingQueriesForUpdate]
    public partial class SceneLoaderSystem : SystemBase
    {
        private EntityQuery _newRequests;

        protected override void OnCreate()
        {
            _newRequests = GetEntityQuery(typeof(SceneLoader));
        }

        protected override void OnUpdate()
        {
            var requests = _newRequests.ToComponentDataArray<SceneLoader>(Allocator.Temp);
            var sceneSystem = World.GetExistingSystem<SceneSystem>();

            for (int i = 0; i < requests.Length; i += 1)
            {

                SceneSystem.LoadSceneAsync(World.Unmanaged, requests[i].sceneReference);
            }

            requests.Dispose();
            EntityManager.DestroyEntity(_newRequests);
        }
    }
}