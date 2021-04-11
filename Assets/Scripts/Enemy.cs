using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Enemy_Health = 100;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy_Health <= 0)
        {
            
            Destroy(gameObject);
        }
        
    }
    public void BeHurted(int pain)
    {
        Enemy_Health -= pain;
    }
}
