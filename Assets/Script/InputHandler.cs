using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
