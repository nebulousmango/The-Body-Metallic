using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Podium : MonoBehaviour
{
    [SerializeField] private string S_WinScene;
    [SerializeField] private GameObject Go_InteractOverlayUI;
    bool WinTriggerEntered = false;

    private void Start()
    {
        Go_InteractOverlayUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && WinTriggerEntered)
        {
            SceneManager.LoadScene(S_WinScene);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            Go_InteractOverlayUI.SetActive(true);
            WinTriggerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            Go_InteractOverlayUI.SetActive(false);
            WinTriggerEntered = false;
        }
    }
}