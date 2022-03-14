using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @author Alexa Summers pretty much
* Class PlayerMovement handles the player's movement using WASD, as well as 
* animations */
public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 1; // Sets initial movement speed
    public float Gravity = -9.81f;

    private CharacterController _controller; //Add character controller component to player
    private Animator _animator; //Adds animator
    private Vector3 _velocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 3.0f;

    //Stores player location
    public Vector3 location;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _controller = GetComponent<CharacterController>(); // reference to character controller component
    }

    // Update is called once per frame
    void Update()
    {
        _groundedPlayer = _controller.isGrounded; //was the character touching the ground during the last frame? Accessing the character controller's isGrounded

        if (_groundedPlayer && _velocity.y < 0)
        {
            _velocity.y = 0f; //if the character was grounded in the last frame and is moving in a negative velocity (falling down), set the speed and direction to zero

        }

        location = new Vector3(transform.position.x, 0, transform.position.z); //store location of player for enemy object
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //predefined axes in Unity linked to WASD controls
        move = transform.TransformDirection(move);

        _controller.Move(move * Time.deltaTime * moveSpeed);//moves character in the given direction from Vector3

        if (Input.GetButton("Jump") && _groundedPlayer) //predefined jump in unity mapped to the space bar
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * Gravity); //Change velocity to represent a jumping behavior
            _animator.SetTrigger("PlayerJump");
        }

        _velocity.y += Gravity * Time.deltaTime; //setting velocity in the y direction to the acceleration of gravity in the relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); // Movement based on velocity

        //Sets movement speed depending on normal key press, sprinting (left shift), and idle (no input)
        if (move != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
        {
            // Walk
            moveSpeed = 5;
            _animator.SetFloat("PlayerMovement", 0.5f, 0.1f, Time.deltaTime);
        }
        else if (move != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            // Run
            moveSpeed = 10;
            _animator.SetFloat("PlayerMovement", 1f, 0.1f, Time.deltaTime);
        }
        else
        {
            // Idle
            _animator.SetFloat("PlayerMovement", 0f, 0.1f, Time.deltaTime);
            moveSpeed = 5;
        }
    }
}
