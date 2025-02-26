using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFish : DangerousObject
{
    private Character player;

    [SerializeField] float speed = 5f;

    private void Awake()
    {
        player = FindObjectOfType<Crabby>();
    }

    protected override void Start()
    {
        base.Start();
        Fly(speed);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject != player.gameObject)
        {
            TakeDamage(collision);
            //impact = true;
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        if(collision.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

    protected override void TakeDamage(Collider2D collision)
    {
        Character other = collision.gameObject.GetComponent<Character>();
        other.isDie = true;
        //other.rb.isKinematic = true;
        if (other.isDieSkeletonFish == false)
        {
            other.rb.gravityScale = 0f;
            collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + .5f);
            //other.isDieSkeletonFish = true;
        }

        Vector2 forceDirection = this.gameObject.GetComponent<Rigidbody2D>().velocity.normalized;
        other.rb.velocity += forceDirection * 15f;

        other.isDieSkeletonFish = true;
        //float xX = collision.transform.position.x - transform.position.x;
        //Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        //if (xX > 0)
        //{
        //    vel.x = speed;
        //    other.rb.velocity = vel;
        //}
        //else if (xX < 0)
        //{
        //    vel.x = -speed;
        //    other.rb.velocity = vel;
        //}

        other.SetState(new DeathGroundState());
        //rb_other.AddForce(new Vector2(1f, 4f) ,ForceMode2D.Force);
    }

    private void Fly(float flyForce)
    {
        Vector2 forceDirection = (this.transform.position - player.gameObject.transform.position).normalized;

        Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;

        if(forceDirection.x < 0)
        {
            vel.x = -flyForce;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        else
        {
            vel.x = flyForce;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
    }
}
