using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby : Character
{
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private GameObject bulletPrefab;
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
            //attackArea.gameObject.SetActive(true);
            timeAtk = delayAttack;
            SpawnBullet();
            canAttack = false;
        }
    }

    void SpawnBullet()
    {
        Instantiate(bulletPrefab, bulletPos.transform.position, Quaternion.identity);
    }
    public void DeadGround()
    {
    }

    public void DeadBubble()
    {
    }
}
