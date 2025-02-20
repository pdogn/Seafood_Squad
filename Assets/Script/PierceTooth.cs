using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceTooth : Character
{
    private ICommand deathGroundCommand = new DeathGroundCommand();
    private ICommand deathSkeletonFishCommand = new DeathSkeletonFishCommand();
    private ICommand deathBubbleCommand = new DeathBubbleCommand();

    public override void Attack()
    {
        Debug.Log("đánh bay");
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

    public void DeadBubble()
    {
        deathBubbleCommand.Execute(this);
    }
}
