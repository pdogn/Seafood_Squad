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
        if(characters[currentIndex].isDie == false)
        {
            characters[currentIndex].isUsing = true;
        }
        return characters[currentIndex];
    }

    public void SwitchCharacter()
    {
        //Số nhân vật còn sống
        int charAlives = checkManyCharAlive();
        Debug.Log("Sw==" + charAlives);
        //charater truoc khi switch
        if (!characters[currentIndex].isDie && charAlives > 1)
        {
            characters[currentIndex].SetState(new IdleState());
            characters[currentIndex].isUsing = false;
        }
        //switch
        //currentIndex = (currentIndex + 1) % characters.Count;
        //OnCharacterSwitch?.Invoke(GetCurrentCharacter());
        if (charAlives < 1)
        {
            Debug.Log("Không còn nhân vật nào sống!");
            return;
        }
        do
        {
            currentIndex = (currentIndex + 1) % characters.Count;
            OnCharacterSwitch?.Invoke(GetCurrentCharacter());
            Debug.Log("Swwitchhh");
        } while (characters[currentIndex].isDie);
    }

    int checkManyCharAlive()
    {
        int count = 0;
        foreach(Character charAlive in characters)
        {
            if (!charAlive.isDie)
            {
                count++;
            }
        }
        return count;
    }
}
