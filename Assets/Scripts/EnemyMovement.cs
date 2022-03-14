using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author Jacob Patten
* Class EnemyMovement moves the enemy towards the player */
public class EnemyMovement : MonoBehaviour
{
    // Creates many variables including game objects, distance between player 
    // and enemy, and enemy speed.
    public GameObject playerObject;
    private CharacterController _controllerEnemy;
    Vector3 playerLocation;
    Vector3 enemyLocation;
    float distance;
    public float enemySpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Takes the player game object and starts coroutine to move to player
        playerObject = GameObject.FindGameObjectWithTag("Player");
        _controllerEnemy = GetComponent<CharacterController>();
        StartCoroutine(MoveToPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        // Updates player and enemy location
        playerLocation = playerObject.GetComponent<PlayerMovement>().location;
        enemyLocation = new Vector3(transform.position.x, 1, transform.position.z);
        distance = Vector3.Distance(playerLocation, enemyLocation);
    }

    // Uses coroutine and waitforseconds to approach the player at speeds depending
    // on the distance between the enemy and player
    IEnumerator MoveToPlayer()
    {
        yield return new WaitForSecondsRealtime(5);
        while (true)
        {
            _controllerEnemy.transform.position = Vector3.Lerp(enemyLocation, playerLocation, Time.deltaTime * distance * enemySpeed);
            yield return new WaitForSecondsRealtime(0.25f);
        }
    }
}