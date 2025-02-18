using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterState currentState;
    public string characterName;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform rotate;
    public float speed = 5f;
    public float jumpForce = 7f;
    float dirX;
    [SerializeField]
    public Transform groundCheck;
    public bool isGrounded;
    public bool hasJumped;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = 0.2f;

    private void Start()
    {
        rotate = gameObject.GetComponent<Transform>();
    }

    public void SetState(ICharacterState newState)
    {
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;
        currentState.Enter(this);
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        currentState?.Update(this);
    }

    private void FixedUpdate()
    {
        GroundCheck();
    }

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void Idle()
    {
        Debug.Log(characterName + " is Idleing!");
        rb.velocity = new Vector2(0, rb.velocity.y);
    }

    public void Move()
    {
        Debug.Log(characterName + " is Running!");
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
    }

    public void Jump()
    {
        //isGround = false;
        if (isGrounded && hasJumped == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
        hasJumped = true;
        if (rb.velocity.y > .1f)
        {
            Debug.Log(characterName + " is jumping!");
            SetAnimation("Jump");
        }
        else if (rb.velocity.y < -.1f)
        {
            Debug.Log(characterName + " is falling!");
            SetAnimation("Fall");
        }
        //kiểm tra khi hoàn thành 1 lần nhảy
        if(hasJumped && isGrounded)
        {
            hasJumped = false;
            SetState(new IdleState());
        }
    }

    public void Attack()
    {
        Debug.Log(characterName + " is Attacking!");
    }

    void GroundCheck()
    {
        isGrounded = false;
        Collider2D[] coliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
        if(coliders.Length > 1)
        {
            isGrounded = true;
        }
    }
}
