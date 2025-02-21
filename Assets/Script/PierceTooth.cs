using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceTooth : Character
{
    private ICommand deathGroundCommand = new DeathGroundCommand();
    private ICommand deathSkeletonFishCommand = new DeathSkeletonFishCommand();
    private ICommand deathBubbleCommand = new DeathBubbleCommand();

    [SerializeField] Transform attackArea;

    public override void Start()
    {
        base.Start();
        canAttack = true;
    }

    public override void Attack()
    {
        if (IsAnimationFinished("Attack"))
        {
            attackStateComplete = true;
            SetState(new IdleState());
        }
        else
        {
            attackStateComplete = false;
        }
        
        if (canAttack)
        {
            Debug.Log("đánh bay");

            attackArea.gameObject.SetActive(true);
            canAttack = false;
            timeAtk = delayAttack;
            attackArea.gameObject.SetActive(true);
        }
        
    }

    //bool IsAnimationFinished(string animationName)
    //{
    //    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
    //    return stateInfo.IsName(animationName) && stateInfo.normalizedTime >= 1.0f;
    //}


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
