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
    }
    public void Exit(Character character)
    {
        Debug.Log("Exit Idle State");
        character.UpdatePhysic();
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
        character.UpdatePhysic();
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
        character.UpdatePhysic();
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
        character.Attack();
    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit Attack State");
    }
}

public class DeathGroundState : ICharacterState
{
    public void Enter(Character character)
    {
        
    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit Deatd State");
    }
}

public class DeathSkeletonFishState : ICharacterState
{
    public void Enter(Character character)
    {

    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit DeatdSkeletonFish State");
    }
}

public class DeathBubbleState : ICharacterState
{
    public void Enter(Character character)
    {

    }
    public void Update(Character character) { }
    public void Exit(Character character)
    {
        Debug.Log("Exit DeatdSkeletonFish State");
    }
}
