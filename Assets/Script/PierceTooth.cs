using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceTooth : Character
{
    //private ICommand deathGroundCommand = new DeathGroundCommand();
    //private ICommand deathSkeletonFishCommand = new DeathSkeletonFishCommand();
    //private ICommand deathBubbleCommand = new DeathBubbleCommand();

    [SerializeField] Transform attackArea;

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
            attackArea.gameObject.SetActive(true);
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

    public void DeadBubble()
    {
        
    }
}
