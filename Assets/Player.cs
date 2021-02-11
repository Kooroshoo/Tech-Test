using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int speed = 500;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Getting the rigidbody attached to the player.
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    // Move the player based on the player input.
    void PlayerMovement()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        // ClampMagnitude will prevent the vector from being longer than the length specified, so that it prevents the object moving faster diagonally.
        Vector3 playerVelocity = Vector3.ClampMagnitude(new Vector3(xMov, 0, zMov), 1);
        rb.velocity = playerVelocity * speed * Time.deltaTime;
    }
}
