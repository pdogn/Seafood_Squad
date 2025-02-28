using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth : DangerousObject
{
    private Character player;

    private void Awake()
    {
        player = FindObjectOfType<PierceTooth>();
    }

    private void OnEnable()
    {
        Debug.Log("Ennal");
        StartCoroutine(TeethAttackTime());
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject != player.gameObject)
        {
            TakeDamage(collision);
            //impact = true;
            //this.gameObject.SetActive(false);
        }
    }

    protected override void TakeDamage(Collider2D collision)
    {
        Character other = collision.gameObject.GetComponent<Character>();
        other.isDie = true;
        Vector2 forceDirection = (collision.transform.position - transform.position).normalized;
        forceDirection.y = 4f;
        other.rb.velocity = Vector2.zero;
        other.rb.AddForce(forceDirection * 4f, ForceMode2D.Impulse);
        other.SetState(new DeathGroundState());
        //rb_other.AddForce(new Vector2(1f, 4f) ,ForceMode2D.Force);
    }

    IEnumerator TeethAttackTime()
    {
        yield return new WaitForSeconds(.2f);
        this.gameObject.SetActive(false);
    }
}
