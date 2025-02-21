using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : DangerousObject
{
    [SerializeField]
    private float force = 4f;

    public override void TakeDamage(Collider2D collision)
    {
        Rigidbody2D rb_char = collision.gameObject.GetComponent<Rigidbody2D>();
        collision.gameObject.GetComponent<Character>().SetAnimation("Death");
        Vector2 vel = rb_char.velocity;
        vel.y = force;
        rb_char.AddForce(vel);
    }
}
