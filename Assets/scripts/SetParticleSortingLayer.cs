using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParticleSortingLayer : MonoBehaviour
{

    public string sortigLayerName;
    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = sortigLayerName;
    }

    // Update is called once per frame

}
