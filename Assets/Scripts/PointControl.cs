using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author Jacob Patten
* Class Point Control monitors the player's points and teleports the point block
* when collected */
public class PointControl : MonoBehaviour
{
    // Creates playerObject based of player, as well as points and an empty location
    GameObject playerObject;
    int Points = 0;
    Vector3 newLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the player object
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Ends the game when the win condition of five points is met.
        if (Points == 5)
        {
            print("you win");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    
    // Adds point to Point variable and teleports the point block when it has
    // collided with the player, also displays points and teleports.
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().name == "xbot")
        {
            Points += 1;
            print("You have: " + Points + " Points.");
            Teleport();
        }
    }
    // Teleports the point block to a random location on the floor
    void Teleport()
    {
        newLocation = new Vector3(Random.Range(-25, 25), 0.5f, Random.Range(-25, 25));
        transform.position = newLocation;
        print("The Health has moved!");
    }
}
