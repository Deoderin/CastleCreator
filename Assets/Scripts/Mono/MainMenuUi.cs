using System.Collections;
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

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
