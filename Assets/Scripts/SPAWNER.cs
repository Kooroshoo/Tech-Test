using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SPAWNER : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float avoidDistance = 8.0f;
    [SerializeField] float speed = 10.0f;
    [SerializeField] float rotationSpeed = 120.0f;
    [SerializeField] GameObject[] itemsToDrop;

    bool canDropItems = true;

    NavMeshAgent agent;

    Renderer cubeRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // assign the navMesh Agent at the start and its attributes
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.angularSpeed = rotationSpeed;

        //set canDropItems to True every two seconds
        InvokeRepeating("ResetCanDropItems", 2f, 2f);

        // //Get the Renderer component from the cube so that we can change its colors
        cubeRenderer = GetComponent<Renderer>();
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
            ChangeColorToDarkBlue();
        }
        else
        {
            ChangeColorToLightBlue();
        }

    }

    // Move away from the player
    void RunAway()
    {
        // player to the SPAWNER vector
        Vector3 dirToSPAWNER = transform.position - player.transform.position;

        // vector that moves away from the player.
        Vector3 newPos = transform.position + dirToSPAWNER/2;

        // calculate the path between the position and the newPos
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(newPos, path);

        // check if the path to the newPos is valid
        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            if (agent.remainingDistance < 2 )
            {
                // move away from the player
                agent.SetDestination(newPos);
            }
        }
        else
        {
            if (agent.remainingDistance < 2)
            {
                // steer the SPAWNER towards the right to prevent it getting stuck in the corners.
                agent.SetDestination(transform.right);
            }
        }
    }

    // Drop random items
    void DropItems()
    {
        int randomNumberPicker = Random.Range(0, itemsToDrop.Length);
        if (itemsToDrop[randomNumberPicker] && canDropItems)
        {
            Instantiate(itemsToDrop[randomNumberPicker], transform.position, Quaternion.identity);
            canDropItems = false;
        }
        else if (!itemsToDrop[randomNumberPicker])
        {
            Debug.LogError("The array itemsToDrop[" + randomNumberPicker + "] has not been assigned any values");
        }
    }

    void ResetCanDropItems() { canDropItems = true; }

    void ChangeColorToDarkBlue()
    {
        if (cubeRenderer.material.color != Color.blue) cubeRenderer.material.SetColor("_Color", Color.blue);
    }

    void ChangeColorToLightBlue()
    {
        if (cubeRenderer.material.color != Color.cyan) cubeRenderer.material.SetColor("_Color", Color.cyan);
    }



}
