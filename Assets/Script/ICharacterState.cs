using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Qu?n l? tr?ng thái nhân v?t
/// </summary>
public interface ICharacterState
{
    void Enter(Character character);
    void Update(Character character);
    void Exit(Character character);

    void Updatelogic(Character character);
}

public class IdleState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log("Enter Idle State");
        character.SetAnimation("Idle");    
    }
    public void Update(Character character) 
    { 
        character.Idle();
        //character.UpdatePhysic();
        Updatelogic(character);
    }
    public void Updatelogic(Character character)
    {
        if(character.dirX != 0)
        {
            character.SetState(new RunState());
        }
    }
    public void Exit(Character character)
    {
        Debug.Log("Exit Idle State");
        //character.UpdatePhysic();
    }
}

public class RunState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log("Enter Run State"); 
        character.SetAnimation("Run");
    }
    public void Update(Character character)
    {
        character.Move();
        //character.UpdatePhysic();
        Updatelogic(character);
    }
    public void Updatelogic(Character character)
    {
        if (character.isGrounded)
        {
            if (character.dirX == 0)
            {
                character.SetState(new IdleState());
            }
        }
        else
        {
            if(character.rb.velocity.y > .1f)
            {
                character.SetState(new JumpState());
            }
        }
    }

    public void Exit(Character character)
    {
        Debug.Log("Exit Run State");
    }
}

public class JumpState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log("Enter Jump State");
        character.SetAnimation("Jump");
    }
    public void Update(Character character) 
    {
        character.Jump();
        //character.UpdatePhysic();
        Updatelogic(character);
    }

    public void Updatelogic(Character character)
    {
        if(character.rb.velocity.y < .1f && character.attackStateComplete)
        {
            character.SetAnimation("Fall");
        }
    }

    public void Exit(Character character)
    {
        Debug.Log("Exit Jump State");
    }
}

public class AttackState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log("Enter Attack State");
        character.SetAnimation("Attack");
        //character.Attack();
    }
    public void Update(Character character) 
    {
        character.Attack();
        Updatelogic(character);
    }


    public void Exit(Character character)
    {
        Debug.Log("Exit Attack State");
    }
    public void Updatelogic(Character character)
    {
        
    }
}

public class DeathGroundState : ICharacterState
{
    public void Enter(Character character)
    {
        character.SetAnimation("Death");
    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit Deatd State");
    }
    public void Updatelogic(Character character)
    {

    }
}

public class DeathSkeletonFishState : ICharacterState
{
    public void Enter(Character character)
    {
        character.SetAnimation("DeathSkeletonFish");
    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit DeatdSkeletonFish State");
    }
    public void Updatelogic(Character character)
    {

    }
}

public class DeathBubbleState : ICharacterState
{
    public void Enter(Character character)
    {
        character.SetAnimation("DeathBubbleState");
    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit DeatdSkeletonFish State");
    }
    public void Updatelogic(Character character)
    {

    }
}
