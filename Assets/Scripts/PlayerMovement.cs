using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D RB2D;
    public SpriteRenderer sprite;
    public float moveSpeed;
    public Animator animator;
    void Start()
    {
        
    }
    void Update()
    {
        playerMovement();
    }
    private void playerMovement()
    {
        //Esta hecho con los documentos de unity https://docs.unity3d.com/Manual/class-InputManager.html
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 velocity =  new Vector2 (horizontalInput * moveSpeed, verticalInput * moveSpeed);
        RB2D.velocity = velocity;
        flipSprite(horizontalInput);
        spriteUpAndDown(verticalInput);
        playerWalking(horizontalInput, verticalInput);
    }
    private void flipSprite(float horizontal)
    {
        if (horizontal < 0) {
            sprite.flipX = true;
            isLookingRight();
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
            isLookingRight();
        }
    }
    void spriteUpAndDown(float vertical)
    {
        if (vertical< 0)
        {
            isLookingFront();
        }
        else if (vertical > 0)
        {
            isLookingUp();
        }
    }
    void playerWalking(float horizontal, float vertical)
    {
        if(horizontal == 0 && vertical== 0)
        {
            stopWalking();
        }
        else
        {
            isWalking();
        }
    }
    void isLookingRight()
    {
        animator.SetTrigger("seeingSide");
    }
    void isLookingUp()
    {
        animator.SetTrigger("seingTop");

    }
    void isLookingFront()
    {
        animator.SetTrigger("seingFront");

    }
    void isWalking()
    {
        animator.SetBool("isWalking", true);
    }
    void stopWalking()
    {
        animator.SetBool("IsWalking", false);
    }
}
