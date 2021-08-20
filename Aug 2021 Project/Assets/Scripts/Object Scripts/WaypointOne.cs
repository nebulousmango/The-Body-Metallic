using UnityEngine;

public class WaypointOne : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() == true && FindObjectOfType<Enemy>().b_alive)
        {
            FindObjectOfType<Enemy>().b_ReachedWaypointOne = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Enemy>() == true && FindObjectOfType<Enemy>().b_alive)
        {
            FindObjectOfType<Enemy>().b_ReachedWaypointOne = false;
        }
    }
}
