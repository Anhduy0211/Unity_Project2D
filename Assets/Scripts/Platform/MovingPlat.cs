using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{

    public float speed = 1.05f, changeDirection = -1;
    public GameObject Knight;
    Vector3 Move;

    // Use this for initialization
    void Start()
    {
        Move = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(2 * Time.deltaTime * speed, 0, 0);

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Ground"))
        {
            speed *= changeDirection;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Knight.transform.parent = transform;
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