using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    void Update()
    {
        Character currentCharacter = CharacterManager.Instance.GetCurrentCharacter();
        //if (Input.GetKey(KeyCode.A) && currentCharacter.hasJumped ==false)
        //{
        //    runCommand.Execute(currentCharacter);
        //}
        //else if (Input.GetKey(KeyCode.D) && currentCharacter.hasJumped == false)
        //{
        //    runCommand.Execute(currentCharacter);
        //}
        ////if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && currentCharacter.hasJumped == false)
        ////{
        ////    idleCommand.Execute(currentCharacter);
        ////}
        //if (Input.GetKeyDown(KeyCode.Space) && currentCharacter.attackStateComplete && !currentCharacter.hasJumped)
        //{
        //    jumpCommand.Execute(currentCharacter);
        //}
        if (Input.GetKeyDown(KeyCode.F) && currentCharacter.canAttack && !currentCharacter.isDie)
        {
            currentCharacter.SetState(new AttackState());
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterManager.Instance.SwitchCharacter();
        }
    }
}
