using System.Collections;
using Unity.Entities;
using Unity.Scenes;
using UnityEditor;
using UnityEngine;

namespace Mono
{
    public class SubSceneLoaderTest : MonoBehaviour
    {
        public SceneAsset subSceneToLoad;
 
        private Entity subScene;

        private void OnEnable()
        {
            LoadSubScene();
        }

        private void OnDestroy()
        {
            UnLoadSubScene();
        }

        private void LoadSubScene()
        {
            var loadParameters = new SceneSystem.LoadParameters
            {
                Flags = SceneLoadFlags.NewInstance
            };
 
            var sceneSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystem<SceneSystem>();
            var state = World.DefaultGameObjectInjectionWorld.Unmanaged.ResolveSystemStateRef(sceneSystem);

            //subScene = SceneSystem.LoadSceneAsync(World.DefaultGameObjectInjectionWorld.Unmanaged, new Hash128, loadParameters);
            state.EntityManager.AddComponentObject(subScene, this);
            Debug.LogError("KEKA");
            
            StartCoroutine(CheckScene());
        }
 
        private void UnLoadSubScene()
        {
            var unloadParameters = SceneSystem.UnloadParameters.DestroyMetaEntities;
 
            SceneSystem.UnloadScene(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene, unloadParameters);
        }
 
        IEnumerator CheckScene()
        {
            while(!SceneSystem.IsSceneLoaded(World.DefaultGameObjectInjectionWorld.Unmanaged, subScene))
            {
                yield return null;
            }
        }
    }
}