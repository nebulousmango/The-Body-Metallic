using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] DoorLevelTwo Door;
    [SerializeField] private GameObject Go_InteractOverlayUI;

    Animator animator;
    bool SwitchTriggerEntered = false;
    bool DoorOpened = false;

    private void Start()
    {
        Go_InteractOverlayUI.SetActive(false);
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && SwitchTriggerEntered && !DoorOpened)
        {
            animator.SetTrigger("PressSwitch");
            Door.OpenDoor();
            GetComponent<BoxCollider>().enabled = false;
            Go_InteractOverlayUI.SetActive(false);
            DoorOpened = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            Go_InteractOverlayUI.SetActive(true);
            SwitchTriggerEntered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true)
        {
            Go_InteractOverlayUI.SetActive(false);
            SwitchTriggerEntered = false;
        }
    }

}
