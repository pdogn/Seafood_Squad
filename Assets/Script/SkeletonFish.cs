using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFish : DangerousObject
{
    [SerializeField]
    private Character player;

    [SerializeField] float speed = 5f;

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
        }
    }

    protected override void TakeDamage(Collider2D collision)
    {
        Character other = collision.gameObject.GetComponent<Character>();
        other.isDie = true;

        //Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
        //forceDirection.y = 4f;
        //other.rb.velocity = Vector2.zero;
        //other.rb.AddForce(forceDirection * 4f, ForceMode2D.Impulse);
        other.SetState(new DeathGroundState());
        //rb_other.AddForce(new Vector2(1f, 4f) ,ForceMode2D.Force);
    }

    private void Fly(float flyForce)
    {
        Vector2 forceDirection = (this.transform.position - player.gameObject.transform.position).normalized;

        Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;

        if(forceDirection.x < 0)
        {
            vel.x = flyForce;
        }
        else
        {
            vel.x = -flyForce;
        }
        this.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
    }

    //private  void SetRotate(Character character)
    //{
    //    Vector2 vel = character.GetRotate.localScale;
    //    if (vel.x == 1)
    //    {
    //        speed = initFlyForce * -1;
    //        this.transform.localScale = new Vector2(1, 1);
    //    }
    //    if (vel.x == -1)
    //    {
    //        speed = initFlyForce * 1;
    //        this.transform.localScale = new Vector2(-1, 1);
    //    }
    //}
}
