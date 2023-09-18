using UnityEngine;

public class PauseMenuTwo : MonoBehaviour
{
    [SerializeField] private GameObject Go_PauseMenuUI;
    [SerializeField] private GameObject Go_InteractOverlayUI;
    [SerializeField] private GameObject Go_DeathOverlayUI;
    bool GameIsPaused = false;

    private void Start()
    {
        Go_PauseMenuUI.SetActive(false);
        Go_DeathOverlayUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<PlayerController>().b_alive)
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
        Go_InteractOverlayUI.SetActive(false);
        FindObjectOfType<PauseMenuThree>().Pause();
        GameIsPaused = true;
        Time.timeScale = 0;
    }

    void Resume()
    {
        Go_PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        Time.timeScale = 1;
    }

    public void ShowDeath()
    {
        Go_DeathOverlayUI.SetActive(true);
    }

    public void ChangePauseBool()
    {
        GameIsPaused = false;
    }
}
