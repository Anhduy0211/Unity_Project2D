using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAttack : MonoBehaviour
{
    public float attackdelay = 0.3f;
    // Start is called before the first frame update
    public bool attacking = false;
    public Animator anim;
    public Collider2D trigger;

    private void Awake()// Se chay truoc Start() du` co duoc enable hay  k thi` van chay
    {
        anim = gameObject.GetComponent<Animator>();
        trigger.enabled = false;// Khi chua tan cong thi` AttackTrigger se khong hien
    }
    void Start()// Se khong chay khi k dc enable
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)&& !attacking)
        {
            attacking = true;
            trigger.enabled = true;// hien pham vi tan cong len
            attackdelay = 0.3f;
        }
        if (attacking)
        {
            if (attackdelay > 0)
            {
                attackdelay -= Time.deltaTime;// Chay theo thoi  gian thuc k bi anh huong boi Update
            }
            else
            {
                attacking = false;
                trigger.enabled = false;
            }
        }
        anim.SetBool("Attacking", attacking);
    }
}
