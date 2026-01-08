using UnityEngine;
using UnityEngine.SceneManagement;

public class DCC_LevelManager : MonoBehaviour
{
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    public void PlayGame()
    {
        const string _levelScene = "Level";
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(_levelScene, LoadSceneMode.Single);
    }

    public void LoadReplay()
    {
        const string loadSceneName = "Play Again";
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(loadSceneName, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
