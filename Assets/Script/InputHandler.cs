using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    Character currentCharacter;
    
    private void Start()
    {
        EventManager.Instance.LeftObject += MoveLeft;
        EventManager.Instance.RightObject += MoveRight;
        EventManager.Instance.Stopp += StopMove;
        EventManager.Instance.JumpObject += Jumpp;
        EventManager.Instance.DropObj += Dropp;

        EventManager.Instance.SwitchObj += SwitchChar;
        EventManager.Instance.AttackObject += Attackk;
    }
    void Update()
    {
        currentCharacter = CharacterManager.Instance.GetCurrentCharacter();
        Character currentCharacter2 = CharacterManager.Instance.GetCurrentCharacter();
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
        if (Input.GetKeyDown(KeyCode.F) && currentCharacter2.canAttack && !currentCharacter2.isDie)
        {
            currentCharacter2.SetState(new AttackState());
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CharacterManager.Instance.SwitchCharacter();
        }
    }

    void SwitchChar()
    {
        CharacterManager.Instance.SwitchCharacter();
    }

    private void MoveRight()
    {
        if (!currentCharacter.isUsing) return;
        currentCharacter.dirX = 1;
        currentCharacter.rotate.localScale = new Vector2(-1, 1);
        Debug.Log(currentCharacter.characterName + " ffff!");
    }
    private void MoveLeft()
    {
        if (!currentCharacter.isUsing) return;
        currentCharacter.dirX = -1;
        currentCharacter.rotate.localScale = new Vector2(1, 1);
        Debug.Log(currentCharacter.characterName + " ffff");
    }
    private void StopMove()
    {
        currentCharacter.dirX = 0;
        currentCharacter.rb.velocity = new Vector2(0, currentCharacter.rb.velocity.y);
    }
    private void Jumpp()
    {
        if (!currentCharacter.isUsing) return;
        if (currentCharacter.isGrounded)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            currentCharacter.isPressbtnJump = true;
            currentCharacter.holdBtnTime = 0;
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void Dropp()
    {
        if (!currentCharacter.isUsing) return;
        currentCharacter.isPressbtnJump = false;
    }

    void Attackk()
    {
        Character currentCharacter = CharacterManager.Instance.GetCurrentCharacter();
        if(currentCharacter.canAttack && !currentCharacter.isDie)
        {
            currentCharacter.SetState(new AttackState());
        }
    }
}
