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
    }
    private void flipSprite(float horizontal)
    {
        animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontal));
        if (horizontal < 0) {
            sprite.flipX = true;
        }
        else if (horizontal > 0)
        {
            sprite.flipX = false;
        }
    }
    void spriteUpAndDown(float vertical)
    {
        animator.SetFloat("verticalSpeed", vertical);
    }
}
