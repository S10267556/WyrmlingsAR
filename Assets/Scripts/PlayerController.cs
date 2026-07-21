using UnityEngine;
using UnityEngine.XR.Simulation;
using UnityEngine.XR.ARFoundation;

/// <summary>
/// This script is used to control the player character from a 3rd person pov
/// </summary>
[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))] //Sets components required for the controller to work, prevents accidental removal of important components
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rigidBody; //sets the rigid body

    [SerializeField]
    private FixedJoystick joystick; //Lets the script access the joystick

    [SerializeField]
    private Animator animator; //maybe animations??

    [SerializeField]
    private float moveSpeed; //sets how fast player is able to move

    [SerializeField]
    private GameObject imageTarget; //image where the game spawns

    [SerializeField]
    private GameObject daffodilPlayer;

    [SerializeField]
    private Vector3 moveDirection;

    void Start()
    {
        joystick = FindAnyObjectByType<FixedJoystick>(); //set the joystick at runtime
        
    }


    private void FixedUpdate()
    {
        moveDirection = imageTarget.transform.right * joystick.Horizontal + imageTarget.transform.forward * joystick.Vertical;
        rigidBody.linearVelocity =  new Vector3(moveDirection.x * moveSpeed, rigidBody.linearVelocity.y, moveDirection.z * moveSpeed); //Makes the movement be connected to the joystick through multipiying the joystick movements with the move speed

        if(joystick.Horizontal != 0 || joystick.Vertical != 0) //checks if the player is moving, and rotates the character to face the same direction it's moving
        {
            transform.rotation = Quaternion.LookRotation(rigidBody.linearVelocity);   
        }
    }
}
