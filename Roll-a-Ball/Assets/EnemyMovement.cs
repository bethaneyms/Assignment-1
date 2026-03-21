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

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            Debug.Log("Player found");
        }
        else
        {
            Debug.Log("Player NOT found");
        }

        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            agent.SetDestination(player.position);
            Debug.Log("Setting destination");
        }

        if (anim != null)
        {
            anim.SetFloat("speed_f", agent.velocity.magnitude);
        }
    }
}