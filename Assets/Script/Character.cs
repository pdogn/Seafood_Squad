using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterState currentState;
    [SerializeField]
    private string characterName;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform rotate;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float jumpForce = 7f;
    float dirX;
    [SerializeField]
    public Transform groundCheck;
    public bool isGrounded;
    public bool hasJumped;
    public bool wasGrounded;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundCheckRadius = 0.2f;

    public virtual void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
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
        GroundCheck();
    }

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void UpdatePhysic()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
        if (dirX > 0)
        {
            this.rotate.localScale = new Vector2(-1, 1);
        }
        else if (dirX < 0)
        {
            this.rotate.localScale = new Vector2(1, 1);
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            hasJumped = true;
        }
    }
    public void UpdateLogic()
    {

    }

    public void Idle()
    {
        Debug.Log(characterName + " is Idleing!");
    }

    //di chuyển
    public void Move()
    {
        Debug.Log(characterName + " is Running!");
        //rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
        if(dirX > 0)
        {
            this.rotate.localScale = new Vector2(-1, 1);
        }
        else if (dirX < 0)
        {
            this.rotate.localScale = new Vector2(1, 1);
        }
        else
        {
            SetState(new IdleState());
        }
    }

    //Nhảy
    public void Jump()
    {
        if (rb.velocity.y > .1f)
        {
            Debug.Log(characterName + " is jumping!");
            SetAnimation("Jump");
        }
    }

    //Tấn công
    public virtual void Attack()
    {
        Debug.Log(characterName + " is Attacking!");
    }
    public virtual void GetDamage()
    {
        Debug.Log(characterName + " was Attacked");
    }

    private void GroundCheck()
    {
        //lưu trạng thái trước đó
        wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] coliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius);
        if(coliders.Length > 1)
        {
            isGrounded = true;
        }
        if(!wasGrounded && isGrounded && hasJumped)
        {
            //nhân vật tiếp đất sau khi nhảy
            hasJumped = false;
            SetState(new IdleState());
        }
        if(!isGrounded && rb.velocity.y < .1f)
        {
            //khi nhân vật đang rơi
            hasJumped = true;
            SetAnimation("Fall");
        }
    }
}
