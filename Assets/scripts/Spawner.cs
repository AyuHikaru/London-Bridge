using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] enemies;
    public float interval = 4;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2, interval);
    }
    //��1�ŵ���
    void SpawnEnemy()
    {
        int index = Random.Range(0, 2);
        Instantiate(enemies[index], transform.position, transform.rotation);//localrotation�ֲ�
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
