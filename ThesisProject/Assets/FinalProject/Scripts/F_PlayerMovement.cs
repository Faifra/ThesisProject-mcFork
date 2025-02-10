using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class F_PlayerMovement : MonoBehaviour
{
    private Rigidbody characterRB; // Reference to the Rigidbody component of the character

    private Vector3 movementInput; // Stores movement input received from the player
    public Vector3 movementVector; // Stores the resulting movement vector
    [SerializeField] private float movementSpeed; // Movement speed of the character
    private float originalSpeed; // Store the original movement speed

    void Start()
    {
        characterRB = GetComponent<Rigidbody>(); // Getting the Rigidbody component attached to the character
        originalSpeed = movementSpeed; // Store the original movement speed
    }

    void FixedUpdate()
    {

        if (movementInput != Vector3.zero)
        {
            // Calculate movement vector based on input and current orientation of the character
            movementVector = transform.right * movementInput.x + transform.forward * movementInput.z;
            movementVector.y = 0; //since we are rotating the entire game object we only want to calculate the movement vector along the x and z axis (ignore the vertical component of movement)
        }

        // Check if the crouch key is being held down
        if (Input.GetKey(KeyCode.C))
        {
            // Set the movement speed to half of the original speed
            movementSpeed = originalSpeed / 2;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            // Set the movement speed to double of the original speed
            movementSpeed = originalSpeed * 2;
        }
        else
        {
            // Set the movement speed back to the original speed
            movementSpeed = originalSpeed;
        }

        // Set the velocity of the character's Rigidbody to move it
        characterRB.velocity = (movementVector * Time.fixedDeltaTime * movementSpeed);

    }

    // This method is invoked when there is movement input
    private void OnMovement(InputValue input)
    {
        // Getting movement input values (x and y axes)
        movementInput = new Vector3(input.Get<Vector2>().x, 0, input.Get<Vector2>().y);
    }
    private void OnMovementStop(InputValue input)
    {
        movementVector = Vector3.zero;
    }

}