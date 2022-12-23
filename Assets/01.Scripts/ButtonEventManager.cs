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

    //��ҹ�ư ��������
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



    //������ư�� Ŭ��������
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

  

        //GetChild(1)�ν����ϴ� ���� : 0���� Title
        //�׵� GetChild (0) : ������ �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
        //�׵� GetChild (1) : ������ �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
        //�׵� GetChild (2) : ���� �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
        //�׵� GetChild (3) : ���������� �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
        //�׵� GetChild (4) : ������ �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
        //�׵� GetChild (5) : ������ �ڽĿ�����Ʈ�� Image�� �ٲ��ش�
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

        //���� �� �κ��丮���� �������۾Ⱥ��̰�
        EquipManager.GetInstance().equipDataList.Add(data);
        Inventory.GetInstance().inventoryDatas.Remove(data);

        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().sprite = null;
        Inventory.GetInstance().itemSlots[Slot.slotIndex].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(false);
        itemClickUI.SetActive(false);
              
    }

    //����������ư�� ���� ��
    public void UnEquipButton()
    {

        List<InventoryData> equipDataList = EquipManager.GetInstance().equipDataList;

        InventoryData equipData = null;

        int index = 0;
        for (int i=0; i<equipDataList.Count; i++)
        {
      
            if (equipDataList[i].itemTag.Equals(EquipSlot.equipTag)) //�÷��̾ ������ ��񸮽�Ʈ�� ������ ����� �±װ��� ������
            {
                Inventory.GetInstance().ReleaseItem(equipDataList[i].icon,equipDataList[i].itemTag);
                index = i;  //������ index����
                equipData = equipDataList[i];
                break;
            }
        }
        //�÷��̾ ������ ����� �±װ��� ���Ͽ� �� ����������Ʈ�� icon�� �ʱ�ȭ �� �Ⱥ��̰��Ѵ�.
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
        //�ٷ� ������͸� remove�ϸ� �ε��������� �߻��Ͽ�
        //�ӽõ����͸� ���� �� �� �����͸� �κ��丮�����Ϳ� �־��� �� �����Ѵ�.
        Inventory.GetInstance().inventoryDatas.Add(equipData);
        EquipManager.GetInstance().equipDataList.Remove(equipDataList[index]);
 
        equipClickUI.SetActive(false);


    }

    //���� ������ ItemData���� �޾ƿ� InventoryData�� ������ �������ش�.
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


    //������ ȹ�� ��ưŬ��
    public void GetItemButton()
    {
        
        Inventory.GetInstance().AcquireItem(itemData.isStack, itemData.icon,itemData.itemTag);
        Inventory.GetInstance().inventoryDatas.Add(itemData);

        //Inventory.GetInstance().debugData.Add(itemData.itemTag);
        itemInfoUI.SetActive(false);

        Destroy(GameObject.FindObjectOfType<PlayerInput>().GetHitData().transform.gameObject);
    }

    //��� ��ư Ŭ��
    public void CancelButton()
    {
        itemInfoUI.SetActive(false);
    }

}
