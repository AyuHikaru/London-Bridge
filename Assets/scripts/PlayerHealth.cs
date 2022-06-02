using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer healthBar;
    public float health = 100f;
    public float repeatDamagePeriod = 2f;
    public float hurtForce = 10f;//»÷·É
    public float damageAmount = 10f;//µ¥´Î¼õÑª

    private float lastHitTime;
    private Vector3 healthScale;
    private PlayerControl playerControl;
    private Animator anim;

    public AudioClip[] ouches;
    public AudioSource audioSource;

    void Awake()
    {
        playerControl = GetComponent<PlayerControl>();
        healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        healthScale = healthBar.transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }
  
    void OnCollisionEnter2D(Collision2D collision)//collisionÅö×²Æ÷
    {
        if (collision.gameObject.tag == "Enemy")
        {
            int i = Random.Range(0, ouches.Length);
            audioSource.clip = ouches[i];
            audioSource.Play();
            if (Time.time > lastHitTime + repeatDamagePeriod)
            {
                if (health > 0f)
                {
                    TakeDamage(collision.transform);
                    lastHitTime = Time.time;
                }
            }
        }
    }
    void death()
    {
        Collider2D[] cols = GetComponents<Collider2D>();
        foreach(Collider2D c in cols)
        {
            c.isTrigger = true;
        }
        SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer s in spr)
        {
            s.sortingLayerName = "UI";
        }
        playerControl.enabled = false;
        GetComponentInChildren<Gun>().enabled = false;
        anim.SetTrigger("dead");
        GameObject go = GameObject.Find("UI_HealthBar");
        Destroy(go);
    }
    void TakeDamage(Transform enemy)
    {
        playerControl.bJump = false;
        Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 5f;
        GetComponent<Rigidbody2D>().AddForce(hurtVector * hurtForce);
        health -= damageAmount;
        if(health<=0)
        {
            death();
        }
        UpdateHealthBar();
    }
    public void UpdateHealthBar()
    {
        healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
