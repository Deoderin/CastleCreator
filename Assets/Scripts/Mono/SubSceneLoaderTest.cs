using System.Collections;
using Unity.Entities;
using Unity.Scenes;
using UnityEngine;

namespace Mono
{
    public class SubSceneLoaderTest : MonoBehaviour
    {
        public SubScene subSceneToLoad;
 
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
 
            subScene = SceneSystem.LoadSceneAsync(World.DefaultGameObjectInjectionWorld.Unmanaged, subSceneToLoad.SceneGUID, loadParameters);
 
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