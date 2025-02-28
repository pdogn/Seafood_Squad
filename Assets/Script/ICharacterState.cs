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
    void Update2(Character character);
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

    public void Update2(Character character) { }

    public void Updatelogic(Character character)
    {
        if (character.isGrounded)
        {
            if (character.rb.velocity.x != 0)
            {
                character.SetState(new RunState());
            }
        }
        else
        {
            if (character.rb.velocity.y > .1f)
            {
                character.SetState(new JumpState());
            }
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

    public void Update2(Character character) { }

    public void Updatelogic(Character character)
    {
        if (character.isGrounded)
        {
            if (character.rb.velocity.x == 0)
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

    public void Update2(Character character) { }

    public void Updatelogic(Character character)
    {
        if (character.isGrounded)
        {
            character.SetState(new IdleState());
        }
        else
        {
             if (character.rb.velocity.y < .1f && character.attackStateComplete)
            {
                character.SetAnimation("Fall");
            }
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

    public void Update2(Character character) { }

    public void Exit(Character character)
    {
        Debug.Log("Exit Attack State");
    }
    public void Updatelogic(Character character)
    {
        if (character.isGrounded)
        {
            if (character.attackStateComplete)
            {
                character.SetState(new IdleState());
            }
        }
        else
        {
            if (character.attackStateComplete)
            {
                character.SetState(new JumpState());
            }
        }
    }
}

public class DeathGroundState : ICharacterState
{
    public void Enter(Character character)
    {
        character.SetAnimation("Death");
        if (character.isDie && character.isUsing)
        {
            character.isUsing = false;
            CharacterManager.Instance.SwitchCharacter();
        }
    }
    public void Update(Character character) 
    {
    }

    public void Update2(Character character)
    {
        Updatelogic(character);
    }

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

    public void Update2(Character character)
    {
        Updatelogic(character);
    }
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
    bool trigger = true;
    public void Enter(Character character)
    {
        character.SetAnimation("DeathBubble");
        //if (character.isUnderWater)
        //{
        //    character.rb.gravityScale = -0.7f;
        //}
        //else
        //{
        //    character.rb.gravityScale = 7f;
        //}
    }
    public void Update(Character character) 
    {

    }

    public void Update2(Character character)
    {
        Updatelogic(character);
    }

    public void Exit(Character character)
    {
        Debug.Log("Exit DeatdSkeletonFish State");
    }
    public void Updatelogic(Character character)
    {
        if (!trigger) return;
        if (character.isUnderWater)
        {
            if (character.IsAnimationFinished("DeathBubble"))
            {
                character.rb.gravityScale = -0.7f;
                trigger = false;
            }
        }
        else
        {
            character.rb.gravityScale = 7f;
            trigger = false;
        }
    }
}
