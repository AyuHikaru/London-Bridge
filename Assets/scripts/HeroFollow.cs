using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform playerTran;
    public Vector3 offset = new Vector3(0, 1, 0);//private+[serializefield]
    void Start()
    {
        playerTran = GameObject.Find("hero").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTran != null)
            transform.position = playerTran.position + offset;
    }
}
