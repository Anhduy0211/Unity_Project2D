using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;// libary quản lý scenes để dễ sử dụng hơn
public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseUI;
    public bool pause = false;


    void Start()
    {
        pauseUI.SetActive(pause);
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;// Thay doi bien de hien canvas or an canvas
        }
        if (pause) // Player muốn mở bản PauseMenu và dừng trò chơi
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;// Dừng thời gian chơi
            

        }
        if(pause == false)//  Player tiếp tục chơi
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;//Tiếp tục chơi
          
        }
    
    }
    public void Resume()
    {
        pause = false;// Tiếp tục chơi
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();// Dùng khi build thành app
    }
}
