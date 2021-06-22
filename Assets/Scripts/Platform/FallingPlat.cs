using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlat : MonoBehaviour
{
    public Rigidbody2D r2;
    public float time_delay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)// Khi Knight cham vao falling_plat
    {
        if (collision.collider.CompareTag("Player"))// Tag Player in Unity cua Knight
        {
            StartCoroutine(fall());// Gọi Hàm đặc biệc vì có thời gian chờ
        } 
    }
    IEnumerator fall()
    {
        yield return new WaitForSeconds(time_delay);// Thoi gian cho`
        r2.bodyType = RigidbodyType2D.Dynamic;// Sau do xét Bodytype thanh` Dynamic thi` bục sẽ rơi
        yield return 0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
