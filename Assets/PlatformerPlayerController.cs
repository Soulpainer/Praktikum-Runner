using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    public CharacterController CharacterController;
    public Animator Animator;
    public float Speed;
    public float JumpHeight;

    private Vector3 playerVelocity;
    private Vector3 playerOrientation;

    private void Start()
    {
        playerOrientation = Vector3.up * 90;// Start rotation;
    }
    // Update is called once per frame
    void Update()
    {
        var grounded = CharacterController.isGrounded;
                
        if (grounded && CharacterController.velocity.y < 0)
        {
            playerVelocity.y = 0f;
            playerVelocity.x = 0f;
        }

        if (Input.GetKey(KeyCode.A))// && grounded)//Move Left
        {
            playerOrientation = Vector3.up * 270;
            if (grounded)
            {
                playerVelocity.x = -Speed;
            }
            else {
                playerVelocity.x = Mathf.Max(playerVelocity.x -Speed * Speed * Time.deltaTime, -Speed);
            }

            Animator.SetBool("isRunning", true);
        }
        else if (Input.GetKey(KeyCode.D))// && grounded)//Move Right
        {
            playerOrientation = Vector3.up * 90;

            if (grounded)
            {
                playerVelocity.x = Speed;
            }
            else
            {
                playerVelocity.x = Mathf.Min(playerVelocity.x+ Speed * Speed * Time.deltaTime, Speed);
            }

            Animator.SetBool("isRunning", true);
        }
        else {
            Animator.SetBool("isRunning", false);
        }


        transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, playerOrientation, 360 * 2 * Time.deltaTime);

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            playerVelocity.y = Mathf.Sqrt(JumpHeight * -3.0f * Physics.gravity.y);
            Animator.SetBool("isRunning", false);
            Animator.SetTrigger("Jump");
        }

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        CharacterController.Move(playerVelocity * Time.deltaTime);

    }
}
