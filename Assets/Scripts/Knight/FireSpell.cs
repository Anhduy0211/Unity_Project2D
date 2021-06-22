using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpell : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float firespell_damge = 40;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            collision.SendMessageUpwards("BeHurted", firespell_damge);
            Destroy(this.gameObject);
        }
    }
}
