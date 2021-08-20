using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Go_DeathParticle;
    [SerializeField] Transform player;
    [SerializeField] Transform waypoint1;
    [SerializeField] Transform waypoint2;
    [SerializeField] NavMeshAgent enemy;
    [HideInInspector] public bool b_alive = true;
    [HideInInspector] public bool b_ReachedWaypointOne = true;
    [HideInInspector] public bool b_ReachedWaypointTwo = false;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if(FindObjectOfType<EnemyTrigger>().b_EnteredRoom)
        {
            Follow();
        }
        else
        {
            Patrol();
        }
    }

    public void Patrol()
    {
        if(b_ReachedWaypointTwo && !b_ReachedWaypointOne)
        {
            enemy.SetDestination(waypoint1.position);
        }
        if(b_ReachedWaypointOne && !b_ReachedWaypointTwo)
        {
            enemy.SetDestination(waypoint2.position);
        }
    }

    public void Follow()
    {
        enemy.SetDestination(player.position);
    }

    public void Die()
    {
        b_alive = false;
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        animator.SetTrigger("Explode");
        FindObjectOfType<AudioManager>().PlaySound("Orb");
        GameObject currentParticle = GameObject.Instantiate(Go_DeathParticle, transform);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() == true && FindObjectOfType<PlayerController>().b_alive)
        {
            Die();
            FindObjectOfType<PlayerController>().Explode();
        }
    }
}
