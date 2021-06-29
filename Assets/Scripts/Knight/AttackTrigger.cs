using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int damge = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger == true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("BeHurted",damge);
        }
        if (collision.isTrigger == true && collision.CompareTag("Boss"))
        {
            collision.SendMessageUpwards("BeHurted", damge);
        }
    }
}
