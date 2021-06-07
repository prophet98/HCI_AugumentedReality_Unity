using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class PauseUiHandler : MonoBehaviour
{
    public GameObject pauseUI;

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        CameraDevice.Instance.Start();
    }

    public void QuitToMainMenu()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex - 1);
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        CameraDevice.Instance.Stop();
    }
}