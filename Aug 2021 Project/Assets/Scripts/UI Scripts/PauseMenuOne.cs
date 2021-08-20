using UnityEngine;

public class PauseMenuOne : MonoBehaviour
{
    [SerializeField] private GameObject Go_PauseMenuUI;
    [SerializeField] private GameObject Go_OverlayUI;
    static bool GameIsPaused = false;

    private void Start()
    {
        Go_PauseMenuUI.SetActive(false);
        Go_OverlayUI.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        Go_PauseMenuUI.SetActive(true);
        Go_OverlayUI.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

    void Resume()
    {
        Go_PauseMenuUI.SetActive(false);
        Go_OverlayUI.SetActive(true);
        GameIsPaused = false;
        Time.timeScale = 1;
    }

    public void ChangePauseBool()
    {
        GameIsPaused = false;
    }
}
