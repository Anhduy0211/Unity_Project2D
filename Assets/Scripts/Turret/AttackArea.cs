using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public TurretAI turret;
    public bool isLeft = false;// Ng` choi thuong di den tu tay trai
    // Start is called before the first frame update
    public void Awake()
    {
        turret = gameObject.GetComponentInParent<TurretAI>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay2D(Collider2D collision)// Nguoi choi trong pham vi tan cong
    {
        if (collision.CompareTag("Player"))
        {
            if (isLeft)
            {
                turret.Turret_Attack(false);//Tan cong Trai
            }
           else
            {
                turret.Turret_Attack(true);//Tan cong Phai
            }
        }
    }
}
