using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager Instance { get; private set; }
    public List<Character> characters;
    private int currentIndex = 0;
    public event Action<Character> OnCharacterSwitch;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public Character GetCurrentCharacter()
    {
        characters[currentIndex].isUsing = true;
        return characters[currentIndex];
    }

    public void SwitchCharacter()
    {
        //charater truoc khi switch
        if (!characters[currentIndex].isDie)
        {
            characters[currentIndex].SetState(new IdleState());
            characters[currentIndex].isUsing = false;
        }
        //switch
        currentIndex = (currentIndex + 1) % characters.Count;
        OnCharacterSwitch?.Invoke(GetCurrentCharacter());
    }
}
