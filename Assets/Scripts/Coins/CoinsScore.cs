using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScore : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;

    public PointScore pointscore;
    public SoundManager sounds;
    void Start()
    {
        pointscore = GameObject.FindGameObjectWithTag("Point").GetComponent<PointScore>();// Important
        sounds = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger!=true && collision.CompareTag("Player"))
        {
            sounds.PlaySounds("coins");
            pointscore.point += score;
            Destroy(gameObject);
        }
    }
}
