using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    public Knight knight;
    // Start is called before the first frame update
    void Start()
    {
       
        knight = gameObject.GetComponentInParent<Knight>();// Truy xuat duoc cac phan tu trong class Knight
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // Khi va cham voi Grounded or Wall....
    {
        if(collision.isTrigger == false)// La` Player
        {
            knight.grounded = true; // Dang tren mat dat
        }
      
    }
    private void OnTriggerStay2D(Collider2D collision)// Dang va cham
    {
        if (collision.isTrigger == false)
        {
            knight.grounded = true;
        }     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            knight.grounded = false; // Roi mat dat
            knight.doublejump = true;
        }
         
    }
}
