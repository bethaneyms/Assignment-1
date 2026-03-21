using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
        }

        if (anim != null)
        {
            anim.SetFloat("speed_f", agent.velocity.magnitude);
        }
    }
}