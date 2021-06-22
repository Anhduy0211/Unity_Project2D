using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    public float Turret_Health = 100;

    public float distance;// Khoang cach giua nguoi choi va tru
    public float awakeRange;//Khoang cach tru se awake khi nguoi choi den

    public float timedelay_shoot;// Khoang thoi gian giua nhung lan tan cong
    public float speedshoot = 5f;//Toc do bay cua vien dan
    public float bullettimer;//Gioi han thoi gian

    public bool awake = false;
    public bool lookingRight = true;
    public SpriteRenderer sprite_render;// Color, .....
    public GameObject bullet; // Lay cac thuoc tinh cua Object Bullet
    public Transform target; // Vi tri nguoi choi
    public Animator anim;// Quan ly trang thai awake va lookingRight
    public Transform shootpointL, shootpointR;// Vi tri diem ban trai or phai
                                              // Start is called before the first frame update
    public PointScore pointscore;
    public SoundManager sm;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        sprite_render = GetComponent<SpriteRenderer>();// Cap quyen chinh cac thuoc tinh trong spriteReader

        pointscore = GameObject.FindGameObjectWithTag("Point").GetComponent<PointScore>();// Important

    }
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }
   

    // Update is called once per frame
    void Update()
    {
        RangeCheck();
        anim.SetBool("Awake", awake);
        anim.SetBool("LookRight", lookingRight);
  
        if (target.transform.position.x > this.transform.position.x)// Neu vi tri nguoi chan > vi tri tru thi` nguoi` choi dang dung ben phai
        {
            lookingRight = true;
        }
        if (target.transform.position.x < this.transform.position.x)//Neu vi tri nguoi choi < vi tri tru thi` nguoi choi dang ben trai
        {
            lookingRight = false;
        }
        // Destroy Turret
        if (Turret_Health <= 0)
        {
            Destroy(gameObject);
            pointscore.point += 1;
        }
    }
    void RangeCheck()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);// Khoang cach giua tru va nguoi choi
        if (distance < awakeRange)
        {
            awake = true;
        }
        if (distance > awakeRange)
        {
            awake = false;
        }
     
    }
    public void Turret_Attack(bool attackright)
    {
        bullettimer += Time.deltaTime;
        if(bullettimer>= timedelay_shoot)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize(); //Giup vector giu dung huong 
            if (attackright)
            {
                sm.PlaySounds("shoot_tower");
                GameObject bulletclone;//Tao ban sau cua vien dan;
                //Khoi tao tu ban sau cua bullet, vi tri ban, huong xoay
                bulletclone = Instantiate(bullet, shootpointR.transform.position, shootpointR.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * speedshoot;// Day vien dan theo huong chi dinh
                bullettimer = 0;
            }
            if (attackright==false)
            {
                sm.PlaySounds("shoot_tower");
                GameObject bulletclone;//Tao ban sau cua vien dan;
                //Khoi tao tu ban sau cua bullet, vi tri ban, huong xoay
                bulletclone = Instantiate(bullet, shootpointL.transform.position, shootpointL.transform.rotation) as GameObject;
                bulletclone.GetComponent<Rigidbody2D>().velocity = direction * speedshoot;// Day vien dan theo huong chi dinh
                bullettimer = 0;
            }
        }
    }
    public void BeHurted(int pain)
    {
        Turret_Health -= pain;
        gameObject.GetComponent<Animation>().Play("Redflash");
        //color lam` sau 
    }
}
