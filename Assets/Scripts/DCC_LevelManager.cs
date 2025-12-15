using UnityEngine;
using UnityEngine.SceneManagement;

public class DCC_LevelManager : MonoBehaviour
{
    [SerializeField][Tooltip("Name of the scene which is passed into SceneManager.LoadScene()")] private string sceneName;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level")
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
