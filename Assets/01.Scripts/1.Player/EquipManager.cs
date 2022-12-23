using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//플레이어가 장착한 아이템 데이터목록을 관리할 스크립트 
public class EquipManager : MonoBehaviour
{
    public List<InventoryData> equipDataList = new List<InventoryData>();

    static EquipManager instance = null;


    //장비아이템 슬롯
    [SerializeField]
    Image[] slots;


  

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public static EquipManager GetInstance()
    {
        return instance;
    }

    public void DebugEquipData()
    {
        for(int i=0; i<equipDataList.Count; i++)
        {
            Debug.Log(equipDataList[i].itemTag);
        }
    }

    //Json에서 받아온 데이터를 장비창으로 로드하는 함수

    public void LoadEquipData()
    {
        for (int i = 0; i < equipDataList.Count; i++)
        {
            string tag = equipDataList[i].itemTag;
            switch (tag)
            {
                case "Hat":
                    slots[0].transform.GetChild(0).GetComponent<Image>().sprite=equipDataList[i].icon;
                    slots[0].transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case "Weapon":
                    slots[1].transform.GetChild(0).GetComponent<Image>().sprite = equipDataList[i].icon;
                    slots[1].transform.GetChild(0).gameObject.SetActive(true);

                    break;
                case "Body":
                    slots[2].transform.GetChild(0).GetComponent<Image>().sprite = equipDataList[i].icon;
                    slots[2].transform.GetChild(0).gameObject.SetActive(true);

                    break;
                case "AssistanceWeapon":
                    slots[3].transform.GetChild(0).GetComponent<Image>().sprite = equipDataList[i].icon;
                    slots[3].transform.GetChild(0).gameObject.SetActive(true);

                    break;
                case "Ring":
                    slots[4].transform.GetChild(0).GetComponent<Image>().sprite = equipDataList[i].icon;
                    slots[4].transform.GetChild(0).gameObject.SetActive(true);

                    break;
                case "Gem":
                    slots[5].transform.GetChild(0).GetComponent<Image>().sprite = equipDataList[i].icon;
                    slots[5].transform.GetChild(0).gameObject.SetActive(true);
                    break;
            }

        }

    }



}
