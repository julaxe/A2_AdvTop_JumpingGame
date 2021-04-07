using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform enemy;
    void Start()
    {
        enemy = transform.Find("Enemy");
        float RandomX = Random.Range(-2.4f, 2.4f);
        enemy.position = new Vector3(RandomX, transform.position.y + 1.0f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
