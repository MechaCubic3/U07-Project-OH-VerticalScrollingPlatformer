using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseGame;

    [SerializeField]
    private GameObject exitGame;

    [SerializeField]
    private GameObject toMenu;

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Pivot;

    [SerializeField]
    private GameObject Spin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Spin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
            pauseGame.gameObject.SetActive(true);
            exitGame.gameObject.SetActive(true);
            toMenu.gameObject.SetActive(true);

            Player.gameObject.SetActive(false);

            Pivot.gameObject.SetActive(false);

            Spin.gameObject.SetActive(true);

        }
    }


    public void ResumeGameFunk()
    {
        pauseGame.gameObject.SetActive(false);
        exitGame.gameObject.SetActive(false);
        toMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        Player.gameObject.SetActive(true);

        Pivot.gameObject.SetActive(true);

        Spin.gameObject.SetActive(false);
    }

    public void ToMenuFunk()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void ExitGameFunk()
    {
        Application.Quit();
    }
}
