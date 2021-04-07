using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private GameObject platformWithEnemy;

    [SerializeField]
    static public Queue<GameObject> queuePlatforms;

    private GameObject LastObject;
    
    // Start is called before the first frame update
    void Start()
    {
        queuePlatforms = new Queue<GameObject>();
        CreateNewObject(platform);
        CreateNewObject(platformWithEnemy);
        CreateNewObject(platformWithEnemy);
        CreateNewObject(platformWithEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlatforms();
    }

    void CreateNewObject(GameObject obj)
    {
        GameObject newObj = Instantiate(obj);
        if(queuePlatforms.Count > 0)
        {
            newObj.transform.position = LastObject.transform.position + (Vector3.up * 3.0f); // next platform
        }
        else
        {
            newObj.transform.position = Vector3.zero + (Vector3.down * 2.5f);
        }
        queuePlatforms.Enqueue(newObj);
        LastObject = newObj;
    }

    void UpdatePlatforms()
    {
        if(queuePlatforms.Count > 0)
        {
            if(queuePlatforms.Peek().transform.position.y < -6) // botton of the screen
            {
                CreateNewObject(platformWithEnemy);
                Destroy(queuePlatforms.Dequeue());
            }
        }
    }

    static public void MovePlatforms(Vector3 move)
    {
        foreach (GameObject platform in queuePlatforms)
        {
            platform.transform.position += move;
        }
    }
}
