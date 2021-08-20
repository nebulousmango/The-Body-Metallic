using UnityEngine;

public class DoorLevelTwo : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
        FindObjectOfType<AudioManager>().PlaySound("Switch");
        FindObjectOfType<AudioManager>().PlaySound("Door");
    }
}
