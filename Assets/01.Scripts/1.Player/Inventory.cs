using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//������Data�� ����� class
[System.Serializable]
public class InventoryData
{
    public string itemName;
    public string itemTag;
    public string description;
    public bool isStack;
    public Sprite icon;

    public int count=0;

}

public class Inventory : MonoBehaviour
{
    //������ ����
    public List<Image> itemSlots;


    //�κ��丮 Slot�� ������ ������
    //public List<ItemData> slotItemDatas;

    public List<InventoryData> inventoryDatas = new List<InventoryData>();
    public List<string> debugData = new List<string>();



    static Inventory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static Inventory GetInstance()
    {
        return instance;
    }

    public void DebugInvenData()
    {
        //for (int i = 0; i < inventoryDatas.Count; i++)
        //{
        //    Debug.Log(inventoryDatas.);
            
        //}
    }

    //Json���� ������ Data�� �κ��丮�� Load�ϴ� �Լ�
    public void LoadData()
    {
        //����������Ʈ�� �Ⱥ��̰� ��ġ���ʴ� �������� ��� ->�ٷ� �ش罽�Կ� ������ ����
        //����������Ʈ�� �Ⱥ��̰� ��ġ�� �������� ��� ->�ش罽�Կ� ������ ���� �� ���� ������Ʈ
        //����������Ʈ�� ���̰� ��ġ���ʴ� �������� ��� ->������������ �̵�
        //����������Ʈ�� ���̰� ��ġ�� �����ϸ� ������ icon�̸��� ������ ->���� ��ġ��

        //Debug.Log("dataCount : " + inventoryDatas.Count);
        for (int j = 0; j < inventoryDatas.Count; j++)
        {
            for (int i = 0; i < itemSlots.Count; i++)
            {
                if (!itemSlots[i].transform.GetChild(0).gameObject.activeSelf && !inventoryDatas[j].isStack)
                {
                    itemSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                    itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = inventoryDatas[j].icon;
                    //Debug.Log("Test1");
                    break;
                }
                else if (!itemSlots[i].transform.GetChild(0).gameObject.activeSelf && inventoryDatas[j].isStack && itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite == null)
                {
                    int count = inventoryDatas[j].count;

                    itemSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                    itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = inventoryDatas[j].icon;
                    itemSlots[i].GetComponentInChildren<Text>().text = count.ToString();
                    //Debug.Log("Test2");

                    break;
                }
                else if (itemSlots[i].transform.GetChild(0).gameObject.activeSelf && !inventoryDatas[j].isStack)
                {
                    //��ġ��Ұ����̴� ����ĭ����
                    continue;
                }
                else if (itemSlots[i].transform.GetChild(0).gameObject.activeSelf && inventoryDatas[j].isStack && itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite.name.Equals(inventoryDatas[j].icon.name))
                {
                    itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = inventoryDatas[j].icon;
                    int count = inventoryDatas[j].count;
                    //int count = int.Parse(itemSlots[i].GetComponentInChildren<Text>().text);
                    itemSlots[i].GetComponentInChildren<Text>().text = count.ToString();
                    // itemSlots[i].transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
                    //Debug.Log("Test3");

                    break;
                }
            }
        }

    }






    //������ �����������
    public void AcquireItem(bool isStack, Sprite icon,string itemTag)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            //����������Ʈ�� �Ⱥ��̰� ��ġ���ʴ� �������� ��� ->�ٷ� �ش罽�Կ� ������ ����
            //����������Ʈ�� �Ⱥ��̰� ��ġ�� �������� ��� ->�ش罽�Կ� ������ ���� �� ���� ������Ʈ
            //����������Ʈ�� ���̰� ��ġ���ʴ� �������� ��� ->������������ �̵�
            //����������Ʈ�� ���̰� ��ġ�� �����ϸ� ������ icon�̸��� ������ ->���� ��ġ��

            if (!itemSlots[i].transform.GetChild(0).gameObject.activeSelf && !isStack)
            {
                itemSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;
                itemSlots[i].GetComponent<Slot>().itemTag = itemTag;
                break;
            }
            else if (!itemSlots[i].transform.GetChild(0).gameObject.activeSelf && isStack && itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite == null)
            {
                int count = 0;
                count++;

                itemSlots[i].transform.GetChild(0).gameObject.SetActive(true);
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;
                itemSlots[i].GetComponentInChildren<Text>().text = count.ToString();
                itemSlots[i].GetComponent<Slot>().itemTag = itemTag;

                //itemSlots[i].transform.GetChild(0).GetComponent<Image>().raycastTarget = false;

                break;
            }
            else if (itemSlots[i].transform.GetChild(0).gameObject.activeSelf && !isStack)
            {
                //��ġ��Ұ����̴� ����ĭ����
                continue;
            }
            else if (itemSlots[i].transform.GetChild(0).gameObject.activeSelf && isStack && itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite.name.Equals(icon.name))
            {

                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;
                int count = int.Parse(itemSlots[i].GetComponentInChildren<Text>().text);
                count++;
                itemSlots[i].GetComponentInChildren<Text>().text = count.ToString();
                itemSlots[i].GetComponent<Slot>().itemTag = itemTag;

                // itemSlots[i].transform.GetChild(0).GetComponent<Image>().raycastTarget = false;
                break;
            }
        }
    }


    //������ ������ư�� ������� �ٽ� �κ��丮�� ���ư���.
    public void ReleaseItem(Sprite icon,string itemTag)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            if (!itemSlots[i].transform.GetChild(0).gameObject.activeSelf)
            {
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = icon;
                itemSlots[i].transform.GetChild(0).GetComponent<Image>().gameObject.SetActive(true);
                itemSlots[i].GetComponent<Slot>().itemTag = itemTag;
                break;
            }
            else
            {
                continue;
            }
        }
    }



}
