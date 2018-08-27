using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnSingleplayerClick()
    {
        SceneManager.LoadScene(SceneName.SINGLEPLAYER);
    }

    public void OnMultiplayerClick()
    {
        SceneManager.LoadScene(SceneName.MULTIPLAYER);
    }
}
