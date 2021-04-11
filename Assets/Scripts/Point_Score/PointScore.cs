using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// Su dung cac thanh` phan` trong UI nhu Text,....
using UnityEngine.SceneManagement;
public class PointScore : MonoBehaviour
{
    public int point=0;
    public int highscore = 0;
    
    // Start is called before the first frame update
    public Text pointscoretext;
    public Text highscoretext;
    public Text throughdoortext;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);// Gia tri mac dinh luc rs man` la` 0 neu dang o man` 1
        highscoretext.text = ("Hightscore: " + PlayerPrefs.GetInt("highscore"));// La` gia tri highscore hien tai
        if (PlayerPrefs.HasKey("point"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();// Lay Screen hien tai
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("point");
                point = 0;
            }
            else
            {
                point = PlayerPrefs.GetInt("point");
            }
        }
    }

    // Update is called once per frame
    void Update()
    { 
        pointscoretext.text = ("Point: "+point);
    }
  

}
