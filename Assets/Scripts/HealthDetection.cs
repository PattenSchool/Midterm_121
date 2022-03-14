using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author Jacob Patten
* Class HealthDetection monitors the player's health in terms of colliding with 
* the enemy and subtracting points */
public class HealthDetection : MonoBehaviour
{
    // Creates health with a default of 3
    public int playerHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Nothing Goes Here
    }

    // Update is called once per frame
    void Update()
    {
        // if the player's health reaches zero, it will print a loss message
        // and end the game
        if (playerHealth == 0)
        {
            print("you lose");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
    // Subtracts health point when the player collides with the enemy
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().name == "Enemy")
        {
            StartCoroutine(TakingDamage());
            print("Player health is now: " + playerHealth);
        }
    }
    // Coroutine to subtract health and start a sort of cool down.
    IEnumerator TakingDamage()
    {
        playerHealth -= 1;
        yield return new WaitForSecondsRealtime(5);
    }
}
