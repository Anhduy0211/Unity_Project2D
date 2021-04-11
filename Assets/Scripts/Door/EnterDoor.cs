using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnterDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public int Level = 1;
    public PointScore pointscore;
    void Start()
    {
        pointscore = GameObject.FindGameObjectWithTag("Point").GetComponent<PointScore>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pointscore.throughdoortext.text = ("Press E to enter");
            SaveScore();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                SaveScore();
                SceneManager.LoadScene(Level);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pointscore.throughdoortext.text = "";
        }
    }
    public void SaveScore()
    {
        PlayerPrefs.SetInt("point", pointscore.point);// Luu lai score ng` choi khi di qua cong
    }
}
