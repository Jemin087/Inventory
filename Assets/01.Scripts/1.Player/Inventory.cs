using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//아이템Data를 담아줄 class
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
    //아이템 슬롯
    public List<Image> itemSlots;


    //인벤토리 Slot의 아이템 데이터
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

    //Json에서 가져온 Data를 인벤토리에 Load하는 함수
    public void LoadData()
    {
        //하위오브젝트가 안보이고 겹치지않는 아이템일 경우 ->바로 해당슬롯에 아이템 삽입
        //하위오브젝트가 안보이고 겹치는 아이템일 경우 ->해당슬롯에 아이템 삽입 후 개수 업데이트
        //하위오브젝트가 보이고 겹치지않는 아이템일 경우 ->다음슬롯으로 이동
        //하위오브젝트가 보이고 겹치기 가능하며 포션의 icon이름이 같을때 ->포션 겹치기

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
                    //겹치기불가능이니 다음칸으로
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






    //아이템 습득했을경우
    public void AcquireItem(bool isStack, Sprite icon,string itemTag)
    {
        for (int i = 0; i < itemSlots.Count; i++)
        {
            //하위오브젝트가 안보이고 겹치지않는 아이템일 경우 ->바로 해당슬롯에 아이템 삽입
            //하위오브젝트가 안보이고 겹치는 아이템일 경우 ->해당슬롯에 아이템 삽입 후 개수 업데이트
            //하위오브젝트가 보이고 겹치지않는 아이템일 경우 ->다음슬롯으로 이동
            //하위오브젝트가 보이고 겹치기 가능하며 포션의 icon이름이 같을때 ->포션 겹치기

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
                //겹치기불가능이니 다음칸으로
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


    //아이템 해제버튼을 누를경우 다시 인벤토리로 돌아간다.
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
