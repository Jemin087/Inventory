using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventManager : MonoBehaviour
{
    [SerializeField]
    GameObject itemClickUI;

    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    GameObject equipUI;

    [SerializeField]
    GameObject itemInfoUI;


    [SerializeField]
    GameObject equipClickUI;

    [SerializeField]
    GameObject dropUI;

    InventoryData itemData;

    enum Equip { Hat,Weapon,Body, AssistanceWeapon ,Ring,Gem}

    //취소버튼 눌렀을때
    public void CloseButton(string tag)
    {
        if (tag.Equals("Inventory"))
        {
            itemClickUI.SetActive(false);
        }
        else if (tag.Equals("Equip"))
        {
            equipUI.SetActive(false);
            equipClickUI.SetActive(false);
        }
        else if(tag.Equals("InventoryX"))
        {
            itemClickUI.SetActive(false);
            inventoryUI.SetActive(false);
        }
        else if(tag.Equals("EquipX"))
        {
            equipClickUI.SetActive(false);
        }
        else if(tag.Equals("Drop"))
        {
            dropUI.SetActive(false);
        }

    }



    //장착버튼을 클릭했을때
    public void EquipButton()
    {
        Slot slot = Inventory.GetInstance().itemSlots[Slot.slotIndex].GetComponentInChildren<Slot>();
        Debug.Log(slot.itemTag);

        InventoryData data=null;
        Sprite icon = null;
        foreach (InventoryData item in Inventory.GetInstance().inventoryDatas)
        {
            if(item.itemTag.Equals(slot.itemTag))
            {
                icon=item.icon;
                data = item;
                break;
            }
        }

  

        //GetChild(1)로시작하는 이유 : 0번은 Title
        //그뒤 GetChild (0) : 모자의 자식오브젝트의 Image를 바꿔준다
        //그뒤 GetChild (1) : 무기의 자식오브젝트의 Image를 바꿔준다
        //그뒤 GetChild (2) : 방어구의 자식오브젝트의 Image를 바꿔준다
        //그뒤 GetChild (3) : 보조무기의 자식오브젝트의 Image를 바꿔준다
        //그뒤 GetChild (4) : 반지의 자식오브젝트의 Image를 바꿔준다
        //그뒤 GetChild (5) : 보석의 자식오브젝트의 Image를 바꿔준다
        switch (slot.itemTag)
        {
            case "Hat":
                equipUI.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(true);
                break;
            case "Weapon":
                equipUI.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(true);
                break;
            case "Body":
                equipUI.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(true);
                break;
            case "AssistanceWeapon":
                equipUI.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(true);
                break;
            case "Ring":
                equipUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(true);
                break;
            case "Gem":
                equipUI.transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<Image>().sprite = icon;
                equipUI.transform.GetChild(1).GetChild(5).GetChild(0).gameObject.SetActive(true);
                break;
        }

        //장착 후 인벤토리에서 장비아이템안보이게
        EquipManager.GetInstance().equipDataList.Add(data);
        Inventory.GetInstance().inventoryDatas.Remove(data);

        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().sprite = null;
        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(false);
        itemClickUI.SetActive(false);
              
    }

    //장착해제버튼을 누를 시
    public void UnEquipButton()
    {

        List<InventoryData> equipDataList = EquipManager.GetInstance().equipDataList;

        InventoryData equipData = null;

        int index = 0;
        for (int i=0; i<equipDataList.Count; i++)
        {
      
            if (equipDataList[i].itemTag.Equals(EquipSlot.equipTag)) //플레이어가 착용한 장비리스트와 선택한 장비의 태그값이 같으면
            {
                Inventory.GetInstance().ReleaseItem(equipDataList[i].icon,equipDataList[i].itemTag);
                index = i;  //삭제할 index지정
                equipData = equipDataList[i];
                break;
            }
        }
        //플레이어가 선택한 장비의 태그값을 비교하여 그 하위오브젝트의 icon을 초기화 및 안보이게한다.
        switch(EquipSlot.equipTag)  
        {
            case "Hat":
                equipUI.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(0).GetChild(0).gameObject.SetActive(false);
                break;
            case "Weapon":
                equipUI.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(1).GetChild(0).gameObject.SetActive(false);
                break;
            case "Body":
                equipUI.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(2).GetChild(0).gameObject.SetActive(false);
                break;
            case "AssistanceWeapon":
                equipUI.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(3).GetChild(0).gameObject.SetActive(false);
                break;
            case "Ring":
                equipUI.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(4).GetChild(0).gameObject.SetActive(false);
                break;
            case "Gem":
                equipUI.transform.GetChild(1).GetChild(5).GetChild(0).GetComponent<Image>().sprite = null;
                equipUI.transform.GetChild(1).GetChild(5).GetChild(0).gameObject.SetActive(false);
                break;
        }
        //바로 장비데이터를 remove하면 인덱스에러가 발생하여
        //임시데이터를 만든 후 그 데이터를 인벤토리데이터에 넣어준 후 삭제한다.
        Inventory.GetInstance().inventoryDatas.Add(equipData);
        EquipManager.GetInstance().equipDataList.Remove(equipDataList[index]);
 
        equipClickUI.SetActive(false);


    }

    //내가 선택한 ItemData값을 받아와 InventoryData에 들어가도록 세팅해준다.
    public void SetItemData(ItemData itemData)
    {
        this.itemData = new InventoryData();
        this.itemData.itemName = itemData.ItemName;
        this.itemData.itemTag = itemData.ItemTag;
        this.itemData.description = itemData.Description;
        this.itemData.icon = itemData.Sprite;
        this.itemData.isStack = itemData.IsStack;
        if(itemData.IsStack)
        {
            this.itemData.count += 1;
        }
    }

    public void DropButton()
    {
        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().sprite = null;
        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(false);
    }


    //아이템 획득 버튼클릭
    public void GetItemButton()
    {
        
        Inventory.GetInstance().AcquireItem(itemData.isStack, itemData.icon,itemData.itemTag);
        Inventory.GetInstance().inventoryDatas.Add(itemData);

        //Inventory.GetInstance().debugData.Add(itemData.itemTag);
        itemInfoUI.SetActive(false);

        Destroy(GameObject.FindObjectOfType<PlayerInput>().GetHitData().transform.gameObject);
    }

    //취소 버튼 클릭
    public void CancelButton()
    {
        itemInfoUI.SetActive(false);
    }

}
