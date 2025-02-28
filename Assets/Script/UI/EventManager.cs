using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public UnityAction LeftObject;
    public UnityAction RightObject;
    public UnityAction Stopp;
    public UnityAction JumpObject;
    public UnityAction DropObj;
    public UnityAction AttackObject;
    //public UnityAction pauseObject;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void MoveToLeft()
    {
        if (LeftObject != null)
        {
            LeftObject();
        }
    }
    public void MoveToRight()
    {
        if (RightObject != null)
        {
            RightObject();
        }
    }

    public void Stopped()
    {
        if (Stopp != null)
        {
            Stopp();
        }
    }
    public void Jump()
    {
        if (JumpObject != null)
        {
            JumpObject();
        }
    }
    public void Drop()
    {
        if (DropObj != null)
        {
            DropObj();
        }
    }

    public void Attack()
    {
        if (AttackObject != null)
        {
            AttackObject();
        }
    }

    public void Switch()
    {

    }
}
