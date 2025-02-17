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
    public bool isGround;
    public bool stateCompete;

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

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void Idle()
    {
        Debug.Log(characterName + " is Idleing!");
        rb.velocity = new Vector2(0, rb.velocity.y);
        stateCompete = true;
    }

    public void Move()
    {
        Debug.Log(characterName + " is Running!");
        rb.velocity = new Vector2(speed * dirX, rb.velocity.y);
        stateCompete = true;
    }

    public void Jump()
    {
        //isGround = false;
        stateCompete = false;
        if (isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGround = false;
        }
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
        else
        {
            //isGround = true;
            stateCompete = true;
        }
    }

    public void Attack()
    {
        Debug.Log(characterName + " is Attacking!");
    }
}
