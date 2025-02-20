using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStar : Character
{
    private ICommand deathGroundCommand = new DeathGroundCommand();
    private ICommand deathSkeletonFishCommand = new DeathSkeletonFishCommand();
    public override void Attack()
    {
        Debug.Log("bong bóng");
    }

    public override void GetDamage()
    {

    }

    public void DeadGround()
    {
        deathGroundCommand.Execute(this);
    }

    public void DeadSkeletonFish()
    {
        deathSkeletonFishCommand.Execute(this);
    }
}
