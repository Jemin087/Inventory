using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[System.Serializable]
public class SaveData
{
    public List<string> itemName=new List<string>();
    public List<string> itemTag=new List<string>();
    public List<bool> isStack=new List<bool>();
    public List<Sprite> icon=new List<Sprite>();
    public List<string> description=new List<string>();

    public int count;
}


public class DataManager : MonoBehaviour
{
    string path1;
    string path2;
    // Start is called before the first frame update
    void Start()
    {
        path1 = Path.Combine(Application.dataPath, "Inventory.json");
        path2 = Path.Combine(Application.dataPath, "Equip.json");
        JsonLoad();
        JsonLoadEquip();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path1))
        {
            JsonSave();
        }
        else
        {
            string loadJson = File.ReadAllText(path1);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if(saveData!=null)
            {
                for (int i = 0; i < saveData.itemTag.Count; i++)
                {
                    InventoryData data = new InventoryData();

                    data.itemName = saveData.itemName[i];
                    data.itemTag = saveData.itemTag[i];
                    data.description = saveData.description[i];
                    data.icon = saveData.icon[i];
                    data.isStack = saveData.isStack[i];
                    if (saveData.isStack[i])
                    {
                        data.count = saveData.count;
                    }
                    Inventory.GetInstance().inventoryDatas.Add(data);
                }
            }
        }

       
        //인벤토리에 아이콘보여주기위함
        Inventory.GetInstance().LoadData();
        Debug.Log("인벤로드완료");

    }

    public void JsonLoadEquip()
    {

        SaveData saveData = new SaveData();

        if (!File.Exists(path2))
        {
            JsonSaveEquip();
        }
        else
        {
            string loadJson = File.ReadAllText(path2);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            if (saveData != null)
            {
                for (int i = 0; i < saveData.itemTag.Count; i++)
                {
                    InventoryData data = new InventoryData();

                    data.itemTag = saveData.itemTag[i];
                    data.icon = saveData.icon[i];

                    EquipManager.GetInstance().equipDataList.Add(data);

                }
            }
        }
        EquipManager.GetInstance().LoadEquipData();
        Debug.Log("장비 로드완료");
    }

    public void JsonSaveEquip()
    {
        SaveData saveData = new SaveData();

        for (int i = 0; i < EquipManager.GetInstance().equipDataList.Count; i++)
        {
            saveData.icon.Add(EquipManager.GetInstance().equipDataList[i].icon);
        }
        for (int i = 0; i < EquipManager.GetInstance().equipDataList.Count; i++)
        {
            saveData.itemTag.Add(EquipManager.GetInstance().equipDataList[i].itemTag);
        }

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(path2, json);

        Debug.Log("장비아이템 저장완료");
    }
    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        for(int i=0; i<Inventory.GetInstance().inventoryDatas.Count; i++)
        {
            saveData.itemName.Add(Inventory.GetInstance().inventoryDatas[i].itemName);
        }

        for (int i = 0; i < Inventory.GetInstance().inventoryDatas.Count; i++)
        {
            saveData.itemTag.Add(Inventory.GetInstance().inventoryDatas[i].itemTag);
        }
        for (int i = 0; i < Inventory.GetInstance().inventoryDatas.Count; i++)
        {
            saveData.description.Add(Inventory.GetInstance().inventoryDatas[i].description);
        }
        for (int i = 0; i < Inventory.GetInstance().inventoryDatas.Count; i++)
        {
            saveData.isStack.Add(Inventory.GetInstance().inventoryDatas[i].isStack);
            if(Inventory.GetInstance().inventoryDatas[i].isStack)
            {
                saveData.count = Inventory.GetInstance().inventoryDatas[i].count;
            }
        }
        for (int i = 0; i < Inventory.GetInstance().inventoryDatas.Count; i++)
        {
            saveData.icon.Add(Inventory.GetInstance().inventoryDatas[i].icon);
        }
        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path1, json);

        Debug.Log("인벤 저장완료");
    }

}
