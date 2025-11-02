using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("LEVEL2");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
