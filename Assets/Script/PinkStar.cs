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
            canAttack = false;
        }
    }

    public void DeadGround()
    {
    }

    public void DeadSkeletonFish()
    {
    }
}
