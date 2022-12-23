using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Object/ItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    
    //아이템 이름
    //아이템 종류


    [SerializeField]
    string itemName;

    public string ItemName { get { return itemName; } }


    [SerializeField]
    string itemTag;

    public string ItemTag { get { return itemTag; } }

    [SerializeField]
    bool isStack;

    public bool IsStack { get { return isStack; } }

    [SerializeField]
    int count;

    public int Count 
    { 
        get 
        {
            if (isStack == false)
                return count = 1;
            else
                return count; 
        } 
    }

    [SerializeField]
    Sprite sprite;

    public Sprite Sprite { get { return sprite; } }

    [SerializeField]
    string description;

    public string Description { get { return description; } }

}

