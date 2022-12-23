using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;

    public float offsetX;
    public float offsetY;
    public float offsetZ;

    public float delayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(  target.transform.position.x + offsetX,
                                    target.transform.position.y + offsetY,
                                    target.transform.position.z + offsetZ);

        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * delayTime);
    }
}
