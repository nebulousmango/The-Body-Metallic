using UnityEngine;

public class DoorLevelOne : MonoBehaviour
{
    Animator animator;
    bool DoorOpened;

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.E) && !DoorOpened)
        {
            OpenDoor();
            DoorOpened = true;
        }
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        DoorOpened = false;
    }

    public void OpenDoor()
    {
        animator.SetTrigger("OpenDoor");
        FindObjectOfType<AudioManager>().PlaySound("Switch");
        FindObjectOfType<AudioManager>().PlaySound("Door");
    }
}
