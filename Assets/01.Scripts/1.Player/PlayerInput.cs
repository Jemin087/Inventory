using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    GameObject inventoryUI;

    [SerializeField]
    GameObject equipUI;

    [SerializeField]
    GameObject itemInfoUI;
    RaycastHit itemhit;

    [SerializeField]
    DataManager json;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryUI.activeInHierarchy)
            {
                inventoryUI.SetActive(true);
               // Inventory.GetInstance().DebugInvenData();
            }
            else
            {
                inventoryUI.SetActive(false);
               // json.JsonSave();
            }
        }
        else if(Input.GetKeyDown(KeyCode.E))
        {
            if (!equipUI.activeInHierarchy)
            {
                //EquipManager.GetInstance().DebugEquipData();
                equipUI.SetActive(true);
            }
            else
            {
                equipUI.SetActive(false);
                //json.JsonSaveEquip();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Item"))
                {
                    itemInfoUI.SetActive(true);
                    GameObject.FindObjectOfType<ButtonEventManager>().SetItemData(hit.transform.GetComponent<Item>().GetItemData());
                    itemhit = hit;  //�������� ������ ��� �������� hitData�� �����´�.

                    //����������UI - ������ ������ �־��ֱ�
                    //����������UI - ������ �̸� �־��ֱ�
                    //����������UI - ������ ���� �־��ֱ�
                    itemInfoUI.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = hit.transform.GetComponent<Item>().GetItemData().Sprite;
                    itemInfoUI.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>().text = "������ �̸� :" + hit.transform.GetComponent<Item>().GetItemData().ItemName;
                    itemInfoUI.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = "������ ���� : " + hit.transform.GetComponent<Item>().GetItemData().Description;
                    //Debug.Log(hit.transform.GetComponent<Item>().GetItemData().ItemName);
                }
            }
        }
    }

    public RaycastHit GetHitData()
    {
        return itemhit;
    }
}
