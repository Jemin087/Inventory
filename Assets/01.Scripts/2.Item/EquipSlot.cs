using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EquipSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    GameObject itemClickUI;

    //������ ����� tag�� 
    public static string equipTag;


    //��񽽷��� ���� �� 
    public void OnPointerClick(PointerEventData eventData)
    {
        //Tag�� gameobject�� �̸�
        equipTag = eventData.pointerClick.name;
        itemClickUI.SetActive(true);

        itemClickUI.transform.position = eventData.pointerClick.transform.position;


    }

  

}
