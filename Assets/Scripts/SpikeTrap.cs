using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    // Start is called before the first frame update
    public Knight knight;
    public int damge;
    void Start()
    {
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Knight>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)// Cham vao SpikeTrap
    {
        if (collision.CompareTag("Player"))
        {
            knight.BeDamged = true;
            knight.KnockBack(35f, knight.transform.position);
            knight.Damged(damge);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)// Thoat ra khoi SpikeTrap
    {
        if (collision.CompareTag("Player"))
        {
            knight.BeDamged = false;
            knight.AvoidDamge();
        }
    }

}
