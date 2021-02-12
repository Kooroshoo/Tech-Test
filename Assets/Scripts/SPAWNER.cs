using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SPAWNER : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float avoidDistance = 10.0f;

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        // assign the navMesh at the start
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance between the player and the SPAWNER
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < avoidDistance)
        {
            RunAway();
            DropItems();
        }

        
    }

    // Move away from the player
    void RunAway()
    {
        // player to the SPAWNER vector
        Vector3 dirToSPAWNER = transform.position - player.transform.position;

        // move away from the player and also steer the SPAWNER towards the right to prevent it getting stuck in the corners.
        Vector3 newPos = transform.position + dirToSPAWNER + transform.right ;
        
        agent.SetDestination(newPos);
    }

    // drop random items
    void DropItems()
    {

    }




}
