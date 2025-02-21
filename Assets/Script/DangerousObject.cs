using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DangerBy { trap, arrow, teeth, bubble }
public abstract class DangerousObject : MonoBehaviour
{
    [SerializeField]
    private DangerBy dangerBy;

    public bool impact;

    public bool flyObject;

    public float initflyForce = 5f;
    public float flyForce = 5f;

    private void Start()
    {
        if (!flyObject) return;
        Fly(flyForce);
    }

    private void Update()
    {
        //if (!flyObject) return;
        //Fly(flyForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TakeDamage(collision);
            impact = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            impact = false;
        }
    }

    public virtual void TakeDamage(Collider2D collision)
    {

    }
    public virtual void Fly(float flyForce)
    {
        Vector2 vel = this.gameObject.GetComponent<Rigidbody2D>().velocity;
        vel.x = flyForce;
        this.gameObject.GetComponent<Rigidbody2D>().velocity = vel;
    }

    public virtual void SetRotate(Character character)
    {
        if(character.GetRotate.localScale.x == 1)
        {
            flyForce = initflyForce * -1;
            this.transform.localScale = new Vector2(1, 1);
        }
        if (character.GetRotate.localScale.x == -1)
        {
            flyForce = initflyForce * 1;
            this.transform.localScale = new Vector2(-1, 1);
        }
    }
}
