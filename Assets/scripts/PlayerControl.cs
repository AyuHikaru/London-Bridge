using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveForce = 100.0f;
    public float MaxSpeed = 5;
    public Rigidbody2D HeroBody;
    [HideInInspector]
    public bool bFaceRight=true;//转身
    [HideInInspector]
    public bool bJump = false;
    public float JumpForce = 100;
    private Transform mGroundCheck;
<<<<<<< Updated upstream
=======
    Animator anim;

    public AudioClip[] JumpClips;
    public AudioSource audioSource;
    public AudioMixer audioMixer;
>>>>>>> Stashed changes
    void Start()
    {
        HeroBody = GetComponent<Rigidbody2D>();
        mGroundCheck = transform.Find("GroundCheck");
<<<<<<< Updated upstream
=======
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        if(Mathf.Abs(HeroBody.velocity.x)<MaxSpeed)
        {
            HeroBody.AddForce(Vector2.right * h * MoveForce);

        }
        if(Mathf.Abs(HeroBody.velocity.x) > MaxSpeed)
        {
            HeroBody.velocity = new Vector2(Mathf.Sign(HeroBody.velocity.x) * MaxSpeed, HeroBody.velocity.y);
        }

        if(h>0&&!bFaceRight)
        {
            flip();
        }
        else if(h<0&&bFaceRight)
        {
            flip();
        }

        if (Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << LayerMask.NameToLayer("Ground")))//1向左移动ground位(8)10000000=128 1<<8 按位与
        {
            if(Input.GetButtonDown("Jump"))
            {
                bJump = true;

            }
        }
    }
    private void FixedUpdate()
    {
        if(bJump)
        {
            int i = Random.Range(0, JumpClips.Length);
            audioSource.clip = JumpClips[i];
            audioSource.Play();
            HeroBody.AddForce(Vector2.up * JumpForce);
            bJump = false;
        }
    }
    private void flip()
    {
        Vector3 theScale = transform.localScale;
        
        theScale.x *= -1;
        transform.localScale = theScale;
        HeroBody.velocity = new Vector2(-Mathf.Sign(HeroBody.velocity.x) * MaxSpeed, HeroBody.velocity.y);//加的
        bFaceRight = !bFaceRight;
    }
}
