using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float healthBonus;//��Ѫ��
    public AudioClip collect;//ʰȡ����
    private PickupSpawner pickupSpawner;
    private Animator anim;
    private bool landed=false;
    void Awake()
    {
        pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
        anim = transform.root.GetComponent<Animator>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.health += healthBonus;
            playerHealth.health = Mathf.Clamp(playerHealth.health, 0f, 100f);//ȷ������Ѫ����0-100֮��
            playerHealth.UpdateHealthBar();
            pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());
            AudioSource.PlayClipAtPoint(collect, transform.position, 1);
            Destroy(transform.root.gameObject);

        }
        else if(collision.tag=="ground"&&!landed)
        {
            anim.SetTrigger("Land");
            transform.parent = null;
            gameObject.AddComponent<Rigidbody2D>();
            landed = true;
        }
    }
}
