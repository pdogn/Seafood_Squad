using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : DangerousObject
{
    [SerializeField]
    private float force = 4f;

    protected override void TakeDamage(Collider2D collision)
    {
        Character player = collision.gameObject.GetComponent<Character>();
        if (player.isDie == false)
        {
            player.dirX = 0;
            player.isDie = true;
            player.rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        player.SetState(new DeathGroundState());
    }
}
