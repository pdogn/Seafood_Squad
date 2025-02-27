using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceTooth : Character
{
    //private ICommand deathGroundCommand = new DeathGroundCommand();
    //private ICommand deathSkeletonFishCommand = new DeathSkeletonFishCommand();
    //private ICommand deathBubbleCommand = new DeathBubbleCommand();

    [SerializeField] Transform attackArea;

    public bool isStatic;
    public override void Attack()
    {
        if (IsAnimationFinished("Attack"))
        {
            attackStateComplete = true;
            //attackArea.gameObject.SetActive(false);
        }
        else
        {
            attackStateComplete = false;
        }

        if (canAttack)
        {
            attackArea.gameObject.SetActive(true);
            timeAtk = delayAttack;
            canAttack = false;
        }
    }

    public void DeadGround()
    {
        
    }

    public void DeadSkeletonFish()
    {
        
    }

    public void DeadBubble()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground") && isDieSkeletonFish)
    //    {
    //        Debug.Log("cham tuong");
    //        this.rb.velocity = Vector2.zero;
    //        this.rb.bodyType = RigidbodyType2D.Static;
    //        this.rb.gravityScale = 7f;
    //        isStatic = true;
    //    }
    //    if (collision.gameObject.CompareTag("Player") && !isStatic)
    //    {
    //        isDieSkeletonFish = false;
    //        this.rb.bodyType = RigidbodyType2D.Dynamic;
    //        this.rb.gravityScale = 7f;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" && isDieSkeletonFish && !isStatic)
        {
            Debug.Log("cham tuong tt");
            this.rb.velocity = Vector2.zero;
            this.rb.bodyType = RigidbodyType2D.Static;
            this.rb.gravityScale = 7f;
            isStatic = true;
        }
        if (collision.tag == "Player" && !isStatic && isDie)
        {
            isDieSkeletonFish = false;
            this.rb.bodyType = RigidbodyType2D.Dynamic;
            this.rb.gravityScale = 7f;
            SetState(new DeathGroundState());
        }
    }
}
