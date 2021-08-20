using UnityEngine;

public class Fail : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true && FindObjectOfType<PlayerController>().b_alive)
        {
            FindObjectOfType<PlayerController>().Die();
        }

        if (other.GetComponentInParent<Enemy>() == true && FindObjectOfType<Enemy>().b_alive)
        {
            FindObjectOfType<Enemy>().Die();
            FindObjectOfType<PauseMenuThree>().Explode();
        }
    }
}