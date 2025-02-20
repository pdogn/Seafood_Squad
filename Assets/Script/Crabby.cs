using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crabby : Character
{
    private ICommand deathGroundCommand = new DeathGroundCommand();
    private ICommand deathBubbleCommand = new DeathBubbleCommand();
    public override void Attack()
    {
        Debug.Log("bắn");
    }

    public override void GetDamage()
    {

    }

    public void DeadGround()
    {
        deathGroundCommand.Execute(this);
    }

    public void DeadBubble()
    {
        deathBubbleCommand.Execute(this);
    }
}
