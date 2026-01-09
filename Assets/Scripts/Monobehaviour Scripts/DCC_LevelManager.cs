using UnityEngine;
using UnityEngine.SceneManagement;

public class DCC_LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _HUD;
    [SerializeField] private GameObject _messagePanel;
    [SerializeField] private GameObject _pauseMenu; 

    private bool _isPaused = false;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
            {
                PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
            {
                UnpauseGame();
            }
        }
    }
    public void PlayGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void LoadReplay()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene("Play Again", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        _isPaused = true;

        _pauseMenu.SetActive(true);

        if(_messagePanel.activeSelf)
        {
            _messagePanel.SetActive(false);
        }

        _HUD.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        _pauseMenu.SetActive(false);
        _HUD.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1;
        _isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        _isPaused = false;
        Time.timeScale = 1;

        SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
    }
}
