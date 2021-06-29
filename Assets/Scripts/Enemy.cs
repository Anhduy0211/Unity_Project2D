using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Enemy_Health = 100;
    public float Maxspeed = 3;
    public float Speed = 1.05f;
    public Rigidbody2D mybody;
    [SerializeField]
    private GameObject effect;
    Knight knight;

    public bool drop;
    public GameObject itemdrop;
    public Transform DropPoint;
 
    [SerializeField] private GameObject FloatingPoint;

    public int score;
    PointScore pointScore;
    public bool moveRight;
    void Start()
    {
        mybody = gameObject.GetComponent<Rigidbody2D>();
        knight = GameObject.FindGameObjectWithTag("Player").GetComponent<Knight>();
        pointScore = GameObject.FindGameObjectWithTag("Point").GetComponent<PointScore>();// Important
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Enemy_Health <= 0)
        {
            ShowPoint("+"+score.ToString());
            pointScore.point += score;
            if (drop)
            {
                Instantiate(itemdrop, DropPoint.position, DropPoint.rotation);
           
            }
            Destroy(Instantiate(effect, transform.position, transform.rotation), 0.5f);
            Destroy(gameObject);
        }
        if (moveRight)
        {
            transform.Translate(2 * Time.deltaTime * Speed, 0, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.Translate(-2 * Time.deltaTime * Speed, 0, 0);
            transform.localScale = new Vector2(1, 1);
        }
        

    }
    void ShowPoint(string text)
    {
        if (FloatingPoint)
        {
            GameObject prefab = Instantiate(FloatingPoint, transform.position, Quaternion.identity);          
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }
    public void BeHurted(int pain)
    {
        if (Enemy_Health > pain)
        {
            GameObject prefab = Instantiate(FloatingPoint, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().color = Color.red;
            prefab.GetComponentInChildren<TextMesh>().text ="-"+ pain.ToString();
            Enemy_Health -= pain;
        }
        else
        {
            Enemy_Health -= pain;
        }
        //KnockBack(5f, this.transform.position);
    }
    public void KnockBack(float Knockpow, Vector2 Distance_knock)
    {
        mybody.velocity = new Vector2(0, 0);
        mybody.AddForce(new Vector2(Distance_knock.x * -30, Distance_knock.y * -Knockpow));// Day lui va day len theo huong nguoc lai tuy` theo X or Y hien tai
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            knight.BeDamged = true;
            knight.KnockBack(10f, knight.transform.position);
            knight.Damged(1);
            
        }
        if (collision.CompareTag("Turn"))
        {
            if (moveRight)
            {
                moveRight = false;
            }
            else
            {
                moveRight = true;
            }
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
