using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStart : MonoBehaviour
{


    public void StartGameMenu()
    {
        SceneManager.LoadScene("MainScene");

        SceneManager.LoadScene("MainScene");
    }
    
    public void ExitGameMenu()
    {
        Application.Quit();
    }

}
