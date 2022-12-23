using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class EquipSlot : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    GameObject itemClickUI;

    //해제할 장비의 tag값 
    public static string equipTag;


    //장비슬롯을 누를 시 
    public void OnPointerClick(PointerEventData eventData)
    {
        //Tag는 gameobject의 이름
        equipTag = eventData.pointerClick.name;
        itemClickUI.SetActive(true);

        itemClickUI.transform.position = eventData.pointerClick.transform.position;


    }

  

}
