using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private ICharacterState currentState;
    public string characterName;
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 5f;
    public float jumpForce = 7f;

    public void SetState(ICharacterState newState)
    {
        if (currentState != null)
            currentState.Exit(this);

        currentState = newState;
        currentState.Enter(this);
    }

    void Update()
    {
        currentState?.Update(this);
    }

    public void SetAnimation(string animationName)
    {
        if (animator != null)
            animator.Play(animationName);
    }

    public void Idle()
    {
        rb.velocity = new Vector2(0, 0);
    }

    public void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void Attack()
    {
        Debug.Log(characterName + " is Attacking!");
    }
}
