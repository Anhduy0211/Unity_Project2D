using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlat : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.03f;
    public GameObject Knight;
    public int changeDirection = -1;
    Vector3 Move;
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move.y += speed;
        this.transform.position = Move;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InvisibleGround"))
        {
            speed *= changeDirection;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Knight.transform.parent = this.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Knight.transform.parent = null;
        }
    }
  
}
