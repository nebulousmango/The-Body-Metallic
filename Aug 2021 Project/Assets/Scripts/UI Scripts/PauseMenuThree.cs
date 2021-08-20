using UnityEngine;
using System.Collections;

public class PauseMenuThree : MonoBehaviour
{
    [SerializeField] private GameObject Go_FollowOverlayUI;
    [SerializeField] private GameObject Go_ExplodeOverlayUI;

    void Start()
    {
        Go_FollowOverlayUI.SetActive(false);
        Go_ExplodeOverlayUI.SetActive(false);
    }

    public void Follow()
    {
        StartCoroutine(FollowUI());
    }

    public void Explode()
    {
        StartCoroutine(ExplodeUI());
    }

    IEnumerator FollowUI()
    {
        Go_FollowOverlayUI.SetActive(true);
        yield return new WaitForSeconds(4);
        Go_FollowOverlayUI.SetActive(false);
    }

    IEnumerator ExplodeUI()
    {
        Go_ExplodeOverlayUI.SetActive(true);
        yield return new WaitForSeconds(4);
        Go_ExplodeOverlayUI.SetActive(false);
    }

    public void Pause()
    {
        Go_FollowOverlayUI.SetActive(false);
        Go_ExplodeOverlayUI.SetActive(false);
    }
}
