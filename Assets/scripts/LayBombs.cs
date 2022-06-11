using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayBombs : MonoBehaviour
{
    [HideInInspector]
    public bool bombLaid = false;//�Ƿ񱻰���
    public int bombCount = 0;//�����е�
    public AudioClip bombsAway;
    public GameObject bomb;

    private Text bombHUD;
    private void Awake()
    {
       // bombHUD = GameObject.Find("ui_bombHUD").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2")&&!bombLaid&&bombCount>0)
        {
            bombCount--;
            bombLaid = true;
            AudioSource.PlayClipAtPoint(bombsAway, transform.position);
            Instantiate(bomb, transform.position, transform.rotation);
        }
    }
}
