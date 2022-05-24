using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rocket;
    private PlayerControl playerCtrl;
    public float speed = 20f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.root.gameObject.GetComponent<Animator>();
        playerCtrl = transform.root.GetComponent<PlayerControl>();
        anim = transform.root.gameObject.GetComponent<Animator>();//transform.parent.GetComponent<T>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<AudioSource>().Play();
            anim.SetTrigger("shoot");
            if(playerCtrl.bFaceRight)
            {
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(speed, 0);
            }
            else
            {
                Rigidbody2D bulletInstance = Instantiate(rocket, transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
                bulletInstance.velocity = new Vector2(-speed, 0);
            }
        }
    }
}
