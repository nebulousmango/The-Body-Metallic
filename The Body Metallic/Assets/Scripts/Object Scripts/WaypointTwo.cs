using UnityEngine;

public class WaypointTwo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() == true && FindObjectOfType<Enemy>().b_alive)
        {
            FindObjectOfType<Enemy>().b_ReachedWaypointTwo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() == true && FindObjectOfType<Enemy>().b_alive)
        {
            FindObjectOfType<Enemy>().b_ReachedWaypointTwo = false;
        }
    }
}
