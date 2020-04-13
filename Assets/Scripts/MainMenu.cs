using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Options options;

    public void PlayPVP()
    {
        this.options.SetPVPMode();
        StartCoroutine(LoadScene("Game"));
    }

    public void PlayPVCPU()
    {
        this.options.SetPVCPUMode();
        StartCoroutine(LoadScene("Game"));
    }

    public void QuitGame()
    {
        Debug.Log("Quit!!");
        Application.Quit();
    }

    private IEnumerator LoadScene(string scene)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }
}
