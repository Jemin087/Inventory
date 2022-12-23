using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class Slot : MonoBehaviour,IPointerClickHandler,IDragHandler,IBeginDragHandler,IEndDragHandler,IDropHandler
{
    [SerializeField]
    GameObject itemClickUI;

    [SerializeField]
    GameObject dropUI;

    public static int slotIndex;

    Vector2 startPos;

    Rect baseRect;

    public string itemTag;


    void Start()
    {
        baseRect = transform.parent.GetComponent<RectTransform>().rect;
       // Debug.Log(baseRect.width+"--"+baseRect.height);
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        // Debug.Log(eventData.pointerClick.name);

        //몇번 인벤토리의 슬롯을 눌렀는지 Empty/0~19 로 자른다
        //itemTag=
        slotIndex = int.Parse(eventData.pointerClick.name.Substring(5, 1));
        //Debug.Log(eventData.pointerClick.transform.GetChild(0).GetComponent<Image>().sprite.name);
        if (!eventData.pointerClick.transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("Potion"))
            itemClickUI.SetActive(true);

        itemClickUI.transform.position = eventData.pointerClick.transform.position;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPos = this.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 currentPos = eventData.position;
        this.transform.position = currentPos;
    }

  
    public void OnEndDrag(PointerEventData eventData)
    {
        //Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //this.transform.position = startPos;
        Vector2 pos = this.transform.localPosition;
        itemClickUI.SetActive(false);
        this.transform.position = pos = startPos;
        //slotIndex = int.Parse(eventData.pointerClick.name.Substring(5, 1));
        //인벤토리 영역밖으로 버려질 경우
        if (pos.x< baseRect.xMin
        || pos.x > baseRect.xMax
        || pos.y < baseRect.yMin
        || pos.y > baseRect.yMax)
        {
            dropUI.SetActive(true);
            dropUI.transform.position = this.transform.position;
        }
       
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("drop : "+ eventData.pointerEnter.transform.GetComponent<Image>().sprite.name);

        //eventData.pointerEnter.name;

    }
}
