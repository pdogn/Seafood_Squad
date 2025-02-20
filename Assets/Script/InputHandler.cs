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
public class InputHandler : MonoBehaviour
{
    //private ICommand idleCommand = new IdleCommand();
    private ICommand runCommand = new RunCommand();
    private ICommand jumpCommand = new JumpCommand();
    private ICommand attackCommand = new AttackCommand();

    void Update()
    {
        Character currentCharacter = CharacterManager.Instance.GetCurrentCharacter();
        if (Input.GetKey(KeyCode.A) && currentCharacter.hasJumped ==false)
        {
            runCommand.Execute(currentCharacter);
        }
        else if (Input.GetKey(KeyCode.D) && currentCharacter.hasJumped == false)
        {
            runCommand.Execute(currentCharacter);
        }
        //if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && currentCharacter.hasJumped == false)
        //{
        //    idleCommand.Execute(currentCharacter);
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Execute(currentCharacter);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            attackCommand.Execute(currentCharacter);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterManager.Instance.SwitchCharacter();
        }
    }
}
