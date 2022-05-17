using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{      

    public CharacterController controller;
    private Vector3 temp;
    private Vector3 playerVelocity;
    public float speed = 5f;
    public float sprintSpeed = 10f;
    private bool isGrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public float crouchSpeed = 3f;
    float newspeed;
    private PlayerSprint sprint;
    private PlayerCrouch crouch;
    [SerializeField] bool lockCursor = true;
    // Start is called before the first frame update
    void Start()
    {   
        if (lockCursor){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        controller = GetComponent<CharacterController>();
        sprint = GetComponent<PlayerSprint>();
        crouch = GetComponent<PlayerCrouch>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;      
    }
    //receive the inputs for our inputmanager.cs and apply them to out character controller
    public void ProcessMove(Vector2 input,Vector2 targetDir)
    {   
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        if (!crouch.isCrouch){ // if not crouching

        
        if(isGrounded && sprint.isSprintPressed && targetDir.y > 0 && targetDir.x == 0){ // sprint in only forward direction
            newspeed = sprintSpeed;
        }
        else{
            newspeed = speed;   // default speed
        }
        }
        else{
            newspeed = crouchSpeed; //crouch speed if crouching
        }
        if (isGrounded){
            controller.Move(transform.TransformDirection(moveDirection) * newspeed * Time.deltaTime);
            temp = transform.TransformDirection(moveDirection)* newspeed;
        }
        else{
            controller.Move(temp * Time.deltaTime); // Cant change directions mid jump
        }
        playerVelocity.y += gravity * Time.deltaTime; // gravity
        if( isGrounded && playerVelocity.y < 0){
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
        
        
    }
    public void Jump(){
        if (isGrounded && !crouch.isCrouch){ // jump if on the ground and not crouching
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity);
            
        }
    }
}
