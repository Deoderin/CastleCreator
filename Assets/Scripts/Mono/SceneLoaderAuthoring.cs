using Unity.Entities;
using Unity.Entities.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mono
{
    public class SceneLoaderAuthoring : MonoBehaviour
    {
        public UnityEditor.SceneAsset _scene;

        class Baker : Baker<SceneLoaderAuthoring>
        {
            public override void Bake(SceneLoaderAuthoring authoring)
            {
                var reference = new EntitySceneReference(authoring._scene);
                var entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new SceneLoader
                {
                    sceneReference = reference
                });
            }
        }
    }
    
    public struct SceneLoader : IComponentData
    {
        public EntitySceneReference sceneReference;
    }
}