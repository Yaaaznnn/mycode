using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    // --- Public References ---
    // Drag your CharacterController2D component here
    public CharacterController2D controller;
    
    // Drag your Animator component here
    public Animator animator; 

    // --- Public Variables ---
    public float runSpeed = 40f;

    // --- Private State Variables ---
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    // Update runs once per frame. Best for checking inputs.
    
    void Update()
    {
        // 1. Get Horizontal Input
        // Input.GetAxisRaw gives you -1, 0, or 1.
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Tell the Animator what our speed is (Mathf.Abs makes it a positive number)
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        // 2. Check for Jump Input
        // GetButtonDown only runs ONCE when the key is first pressed.
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            
            // Tell the Animator we are jumping
            animator.SetBool("IsJumping", true);
        }

        // 3. Check for Crouch Input
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    
    public void OnLanding()
    {
        // Tell the Animator to stop the jump animation.
        animator.SetBool("IsJumping", false);
    }

    
    public void OnCrouching(bool isCrouching)
    {
        // Tell the Animator whether we are crouching or not.
        animator.SetBool("IsCrouching", isCrouching);
    }

    // FixedUpdate runs on a fixed timer. 
    void FixedUpdate()
    {
        // 4. Apply Movement
        // We tell the controller to move, passing in our input.
        // We multiply horizontalMove by Time.fixedDeltaTime to make it frame-rate independent.
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        // 5. Reset Jump Flag
        // We set jump back to false so we don't jump every physics frame.
        // The input in Update() will set it back to true when the key is pressed again.
        jump = false;
    }
}
