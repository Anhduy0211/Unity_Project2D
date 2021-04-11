using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Knight knight;
    public float lifetime = 2f;// Thoi gian ton tai cua vien dan
    // Start is called before the first frame update
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Knight>();// Lay thuoc tinh cua Knight
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;// Tru` = thoi` gian thuc 1s,2s.....
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if (collision.CompareTag("Player"))
            {
                knight.BeDamged = true;
                knight.KnockBack(5f, knight.transform.position);
                knight.Damged(1);

            }
            Destroy(gameObject);// Sau khi trung nv se Destroy luon
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            knight.BeDamged = false;
            knight.AvoidDamge();
        }
    }
}
