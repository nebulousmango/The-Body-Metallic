using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [HideInInspector] public bool b_EnteredRoom = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<PlayerController>() && !b_EnteredRoom)
        {
            b_EnteredRoom = true;
            FindObjectOfType<PauseMenuThree>().Follow();
        }
    }
}
