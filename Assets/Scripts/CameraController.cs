using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author Alexa Summers pretty much
* Class CameraController handles the camera's movement and control*/
public class CameraController : MonoBehaviour
{
    //[SerializeField] private float _mouseMovement = 2;

    private Transform _parent;
    private Camera _playerCamera;

    // Start is called before the first frame update
    void Start()
    {   // Creates camera variable and locks cursor during game.
        _playerCamera = Camera.main;
        _parent = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Creates float variables based that are constantly updated to monitor
        // mouse/cursor movement
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        // Rotates the camera using the previous floats
        _parent.Rotate(0, horizontalRotation, 0);
        _playerCamera.transform.Rotate(-verticalRotation, 0, 0);
    }
}
