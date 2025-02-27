using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonFish : DangerousObject
{
    private Character master;

    [SerializeField] float speed = 5f;
    [SerializeField] float rotationSpeed = 90f;

    [SerializeField] bool isRoll;

    [SerializeField] Character other;
    //[SerializeField] bool isHitChar;
    //[SerializeField] GameObject HitChar;

    private void Awake()
    {
        master = FindObjectOfType<Crabby>();
    }

    protected override void Start()
    {
        base.Start();
        Fly(this.gameObject, speed);
    }

    private void Update()
    {
        if (isRoll)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;
        }
        if(transform.position.y < -11f)
        {
            Destroy(this.gameObject, .1f);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && !isRoll)
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Destroy(this.gameObject, .1f);
        }
        if(collision.tag == "Player" && master.gameObject != collision.gameObject && collision.gameObject.GetComponent<Character>().isDieSkeletonFish == false && !isRoll)
        {

            other = collision.gameObject.GetComponent<Character>();
            other.isDie = true;
            other.rb.gravityScale = 0;
            if(other.isDieSkeletonFish == false)
            {
                other.transform.position = new Vector3(other.transform.position.x - 1f, other.transform.position.y, other.transform.position.z);
            }
            Fly(collision.gameObject, speed);
            other.isDieSkeletonFish = true;
            other.SetState(new DeathGroundState());
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, .1f);
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isRoll = true;
        }
    }

    //protected override void TakeDamage(Collider2D collision)
    //{
    //    Character other = collision.gameObject.GetComponent<Character>();
    //    other.isDie = true;
    //    other.rb.isKinematic = true;
    //    if (other.isDieSkeletonFish == false)
    //    {
    //        collision.transform.position = new Vector2(collision.transform.position.x, collision.transform.position.y + .5f);
    //        other.isDieSkeletonFish = true;

    //    }

    //    Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
    //    forceDirection.y = 0f;
    //    other.rb.velocity = Vector2.zero;
    //    other.rb.AddForce(forceDirection * 40f, ForceMode2D.Force);

    //    //float xX = collision.transform.position.x - transform.position.x;
    //    //Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;
    //    //if (xX > 0)
    //    //{
    //    //    vel.x = speed;
    //    //    other.rb.velocity = vel;
    //    //}
    //    //else if (xX < 0)
    //    //{
    //    //    vel.x = -speed;
    //    //    other.rb.velocity = vel;
    //    //}

    //    other.SetState(new DeathGroundState());
    //    //rb_other.AddForce(new Vector2(1f, 4f) ,ForceMode2D.Force);
    //}

    private void Fly(GameObject obj, float flyForce)
    {
        Vector2 forceDirection = (this.transform.position - master.gameObject.transform.position).normalized;

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
        obj.GetComponent<Rigidbody2D>().velocity = vel;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && !isHitChar)
    //    {
    //        AddYpos(collision);
    //    }
    //}

    //void AddYpos(Collision2D collision)
    //{
    //    if(!HitChar)
    //    {
    //        HitChar = collision.gameObject;
    //        Transform other = HitChar.transform;
    //        Vector3 otherPos = other.position;
    //        otherPos.y += 0.5f;
    //        other.position = otherPos;
    //        isHitChar = true;
    //    }
    //}
}
