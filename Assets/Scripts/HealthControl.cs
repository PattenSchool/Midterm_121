using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author Jacob Patten
* Class Health Control monitors the player's Health and teleports the health block
* when collected */
public class HealthControl : MonoBehaviour
{
    // Creates player object, health, location variables.
    GameObject playerObject;
    int Health;
    Vector3 newLocation;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing Goes Here
    }

    // Adds health to the playerHealth variable in HealthDetection.cs when colliding
    // with the player, also prints health and teleports.
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().name == "xbot")
        {
            playerObject.GetComponent<HealthDetection>().playerHealth += 1;
            Health = playerObject.GetComponent<HealthDetection>().playerHealth;
            print("Player health is now: " + Health);
            Teleport();
        }
    }
    // Teleports the health block to a random location on the floor
    void Teleport()
    {
        newLocation = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
        transform.position = newLocation;
        print("The Health has moved!");
    }
}
