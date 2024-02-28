using System.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUi : MonoBehaviour
{
    [SerializeField]
    private Button _playGameButton;

    private bool _playScene;
    
    private void Awake()
    {
        _playGameButton.onClick.AddListener(() => StartCoroutine(LoadGameScene()));
    }

    private IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
        
        
        
        //var defaultWorld = World.DefaultGameObjectInjectionWorld;
        //defaultWorld.EntityManager.CompleteAllTrackedJobs();
        //foreach (var system in defaultWorld.Systems)
        //{
        //    system.Enabled = false;
        //}
        //defaultWorld.Dispose();
        
        
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
