using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Knight : MonoBehaviour
{
    public float Maxspeed=3;
    public float Speed = 20f;
    public float JumPow = 230f;
    public bool doublejump = false;

    public bool faceright = true;// Huong mat ve ben nao
    public bool grounded = true;
    public Rigidbody2D r2;
    public Animator anim;
    public SpriteRenderer sprite_render;
    // Heart cho người chơi
    public int OurHeart;
    public int MaxHeart=5;

    public bool BeDamged = true;
    // KnockBAck
    public float powJumpBack = 120f;
    public PointScore pointscore;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>(); // Lay het cac thanh phan trong Rigidbody2D de co quyen truy xuat
        anim = gameObject.GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();// Cap quyen chinh cac thuoc tinh trong spriteReader
        pointscore = GameObject.FindGameObjectWithTag("Point").GetComponent<PointScore>();
        OurHeart = MaxHeart;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", grounded); //Gan field Grounded trong Unity thanh grounded trong C#
        anim.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (grounded) // Nguoi choi dang tren mat dat
            {
                grounded = false;
                r2.AddForce(Vector2.up * JumPow);
            }
            else //Khong tren mat dat thi` duoc nhay lan nua
            {
                if (doublejump)
                {
                    doublejump = false;// Chi duoc nhay 1 lan
                    r2.velocity = new Vector2(r2.velocity.x, 0);// Xet y =0 de khong cong don` lan nhay thu 1
                    r2.AddForce(Vector2.up * (JumPow*0.8f));
                }
            }
        }
        
    }
    //Update cho cac action vat ly
    void FixedUpdate() // Update moi 0.2s
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * Speed * h);// De dieu chinh toc do cua Knight
        if (r2.velocity.x > Maxspeed)
        {
            r2.velocity = new Vector2(Maxspeed, r2.velocity.y);
        }
        if(r2.velocity.x< -Maxspeed)
        {
            r2.velocity = new Vector2(-Maxspeed, r2.velocity.y);
        }
        if(h>0 && !faceright)// Di ve huong phai va muon di qua ben trai
        {
            Flip();
        }
        if(h<0 &&faceright) // Di ve ban trai va muon di qua ben phai
        {
            Flip();
        }
        if (grounded)
        {
            r2.velocity = new Vector2(r2.velocity.x * 0.9f, r2.velocity.y);// Decrease speed each 0.2s if grounded
        }
        //Nếu người chơi hết máu
        if (OurHeart <= 0)
        {
            Death();
        }
    }
    public void Flip()// Lat hinh anh khi doi huong
    {
        faceright = !faceright;// True or False de lat huong
        Vector3 Scale;
        Scale = transform.localScale;// Gia tri X Y Z trong tranform
        Scale.x *= -1;// Lay gia tri X *-1 de lat hinh anh
        transform.localScale = Scale;// Dan gia tri sau khi thay doi hinh anh
    }
    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (PlayerPrefs.GetInt("highscore") < pointscore.point)
        {
            PlayerPrefs.SetInt("highscore", pointscore.point);
        }

    }
    public void Damged(int damge)
    {
       
        if (BeDamged)
        {
            anim.SetBool("Bedamge", BeDamged);
            OurHeart -= damge;
            gameObject.GetComponent<Animation>().Play("Redflash");
        }
       
    }
    public void AvoidDamge()
    {
        if(BeDamged == false)
        {
            anim.SetBool("Bedamge", false);
        }
    }
    public void KnockBack(float Knockpow,Vector2 Distance_knock)
    {
        r2.velocity = new Vector2(0, 0);
        r2.AddForce(new Vector2(Distance_knock.x *100,Distance_knock.y*-Knockpow));// Day lui va day len theo huong nguoc lai tuy` theo X or Y hien tai
    }
}
