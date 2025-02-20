using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    void Execute(Character character);
}
public class IdleCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new IdleState());
    }
}

public class RunCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new RunState());
    }
}

public class JumpCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new JumpState());
    }
}

public class AttackCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new AttackState());
    }
}

public class DeathGroundCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new DeathGroundState());
    }
}

public class DeathSkeletonFishCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new DeathSkeletonFishState());
    }
}
public class DeathBubbleCommand : ICommand
{
    public void Execute(Character character)
    {
        character.SetState(new DeathBubbleState());
    }
}