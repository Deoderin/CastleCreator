using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField]
    private Button _mainMenuButton;

    private void Awake()
    {
        _mainMenuButton.onClick.AddListener(() => StartCoroutine(LoadGameScene()));
    }
    
    private IEnumerator LoadGameScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
