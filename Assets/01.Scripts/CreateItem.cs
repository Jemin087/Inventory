using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItem : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    List<ItemData> itemDatas;

    [SerializeField]
    List<Material> itemMatList;


    [SerializeField]
    GameObject rangeObject;

    BoxCollider rangeColider;

    


    public List<GameObject> itemLists;

    private void Awake()
    {
        rangeColider = rangeObject.GetComponent<BoxCollider>();
    }
    private void Start()
    {
        CreateRandomItem();
    }

    void CreateRandomItem()
    {
        for (int i = 0; i < 10; i++)
        {
            int item = Random.Range(0, 7);
            GameObject gameObject = Instantiate(prefab, Return_RandomPosition(), Quaternion.identity);
            gameObject.AddComponent<Item>();
            gameObject.GetComponent<Item>().itemData = itemDatas[item]; //아이템 data세팅
            gameObject.GetComponent<MeshRenderer>().material = itemMatList[item];   //아이템 mat세팅
            itemLists.Add(gameObject);  //세팅한 오브젝트를 리스트에 넣기
            
        }
    }


    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;

        float range_x = rangeColider.bounds.size.x;
        float range_z = rangeColider.bounds.size.z;

        range_x = Random.Range((range_x / 2) * -1, range_x / 2);
        range_z = Random.Range((range_z / 2) * -1, range_z / 2);

        Vector3 randomPostion = new Vector3(range_x, 0.5f, range_z);

        Vector3 respawnPosition=originPosition+randomPostion;


        return respawnPosition;
    }
}
