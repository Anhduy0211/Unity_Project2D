using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BossMove : MonoBehaviour
{
    public float BossHealth = 100;
    [SerializeField]
    public float movespeed = 1f;
    public Vector3 startPos, endPos;
    private Vector3 nextPos;
    [SerializeField]
    private Transform PosB;
    private Animator anim;
    [SerializeField]
    // Use this for initialization
    private float TimeAttack = 0;
    private bool normalAttack = true;
    [SerializeField]
    private GameObject fireball;
    public SoundManager sounds;
    public Rigidbody2D mybody;
    void Awake()
    {

    }
    void Start()
    {
        sounds = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
        anim = GetComponent<Animator>();
        startPos = transform.localPosition;
        endPos = PosB.localPosition;
        nextPos = endPos;
        StartCoroutine(Spawner());
    }
    private void Update()
    {
        if (BossHealth <= 0)
        {
            Die();
        }
    }
    void LateUpdate()
    {
        Running();
        //CheckAttack();
    }
    void Running()
    {
        //anim.SetTrigger("Move");
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, nextPos, movespeed *
       Time.deltaTime);
        if (Vector3.Distance(transform.localPosition, nextPos) <= 0.1)
        {
            ChangeDirection();
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            ChangeDirection();
            Vector3 temp = transform.localScale;
            temp.x *= -1;
            transform.localScale = temp;
        }
    }
    void ChangeDirection()
    {
        nextPos = nextPos != startPos ? startPos : endPos;
    }
    void CheckAttack()
    {
        TimeAttack += Time.deltaTime;
        if (TimeAttack > 10f)
        {
            anim.SetTrigger("HeavyAtt");
            TimeAttack = 0;
            normalAttack = true;
        }
        if (TimeAttack > 5f && normalAttack)
        {
            anim.SetTrigger("NormalAtt");
            normalAttack = false;
        }
    }
    public void BeHurted(int pain)
    {
        BossHealth -= pain;
        //KnockBack(5f, this.transform.position);
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }
    public void KnockBack(float Knockpow, Vector2 Distance_knock)
    {
        mybody.velocity = new Vector2(0, 0);
        mybody.AddForce(new Vector2(Distance_knock.x * -30, Distance_knock.y * -Knockpow));// Day lui va day len theo huong nguoc lai tuy` theo X or Y hien tai
    }
    // Update is called once per frame
 

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds(2f);
        Vector2 pos = transform.position;
        pos.x -= transform.localScale.x;
        GameObject ob=Instantiate(fireball, pos, transform.rotation);
        sounds.PlaySounds("firespell");
        Destroy(ob,1.5f);
        StartCoroutine(Spawner());
    }


}
