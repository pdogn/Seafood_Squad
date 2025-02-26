using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStar : Character
{
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private GameObject bulletPrefab;
    public override void Attack()
    {
        Debug.Log("bắn bong bóng");
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
            //attackArea.gameObject.SetActive(true);
            timeAtk = delayAttack;
            SpawnBullet();
            canAttack = false;
        }
    }

    public void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.identity);
    }

    public void DeadGround()
    {
    }

    public void DeadSkeletonFish()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isDieSkeletonFish)
        {
            Debug.Log("cham tuong");
            this.rb.velocity = new Vector2(0, rb.velocity.y);
            this.rb.isKinematic = false;
            this.rb.bodyType = RigidbodyType2D.Static;
        }
    }
}
