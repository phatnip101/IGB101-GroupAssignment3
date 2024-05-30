using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Animator anim;

    public float rotSpeed = 10;

    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;

    private CharacterController characterController;
    private float ySpeed;
    private float originalStepOffset;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update(){

        ForwardMovement();

        Turning();

        Actions();

        Dance();

        Moving();

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime;
        

        if (characterController.isGrounded)
        {
            characterController.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
                anim.SetBool("Jumping", true);
            }
        }
        else
        {
            characterController.stepOffset = 0;
            anim.SetBool("Jumping", false);
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    private void ForwardMovement(){
        if(Input.GetKey("w")){
            anim.SetBool("Walking", true);
            if (Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Running", true);
            } else{
                anim.SetBool("Running", false);
            }
        } else if (Input.GetKeyUp("w")) {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    private void Turning(){
        if (Input.GetKey("a")) {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Left", true);
        } else if (Input.GetKey("d")) {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Right", true);
        } else {
            anim.SetBool("Turn Left", false);
            anim.SetBool("Turn Right", false);
        }
    }

    private void Actions() 
    {
        if (Input.GetKeyDown("e")) {
            anim.SetBool("Waving", true);
        } else if (Input.GetKeyUp("e")) {
            anim.SetBool("Waving", false);
        }
    }
    private void Dance()
    {
        if (Input.GetKeyDown("q")) {
            anim.SetBool("Dancing", true);
        } else if (Input.GetKeyUp("q")) {
            anim.SetBool("Dancing", false);
        }
    }
    private void Moving()
    {
        if(Input.GetKeyDown("s")){
            anim.SetBool("Backwards", true);
        } else if(Input.GetKeyUp("s")){
            anim.SetBool("Backwards", false);
        }  
    }
}

