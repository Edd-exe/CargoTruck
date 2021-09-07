using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject carCloneObj;
    public GameObject packetCloneObj;

    public GameObject menuCanvas;
    public GameObject scoreCanvas;
    public GameObject optionsCanvas;
    public GameObject iCanvas;
    public GameObject msgCanvas;
    public GameObject htpCanvas;
    //public GameObject howtoplayPanel;

    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    public TMPro.TextMeshProUGUI highScoretxt;
    public float speed;
    int a =-1;
    int i = 0;

    public void Start()
    {

    }

    public void GrapSetting (int gNum)
    {
       // PlayerPrefs.SentInt("Graph", a);
        QualitySettings.SetQualityLevel(gNum);
        Debug.Log(gNum);
    }


    public void Update() 
    {
        // ana menu kamera hareket

        transform.Translate(0, speed* a * Time.deltaTime, 0);
        
        if (transform.position.y <= 3f)
        {
            a=1;
        }

        if (transform.position.y >= 4f)
        {
            a=-1;
        }


    
        if (i == 1)
        {
            t1.SetActive(true);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);                
        }
            
        if (i == 2)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            t3.SetActive(false);
            t4.SetActive(false);               
        }
            
        if (i == 3)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);
            t4.SetActive(false);
        }
            
        if (i == 4)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(true);
        }


    }

     // menu scenes 
    public void play()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        
        //SceneManager.LoadScene(SceneManager.GetActiveScene().GameScene);
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void ScoreTable()
    {
        menuCanvas.SetActive(false);
        scoreCanvas.SetActive(true);

        if (PlayerPrefs.HasKey("highScore"))
        {
            Debug.Log(PlayerPrefs.GetFloat("highScore"));
            highScoretxt.text = PlayerPrefs.GetFloat("highScore").ToString("0");
        }
    }

    public void btnBack()
    {
        menuCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
    }

        public void btnBackP()
    {
        optionsCanvas.SetActive(true);
        iCanvas.SetActive(false);
        msgCanvas.SetActive(false);
        htpCanvas.SetActive(false);
        i = 0;
    }


/////////////////

    public void options()
    {
        menuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);       
    }

        public void btni()
        {
            optionsCanvas.SetActive(false);
            iCanvas.SetActive(true);
        }

        public void btnMessage()
        {
            optionsCanvas.SetActive(false);
            msgCanvas.SetActive(true);
        }


        //how to play
        public void btnHTP()
        {
            optionsCanvas.SetActive(false);
            htpCanvas.SetActive(true);
            i = 1;
        }

        public void btnLeft()
        {
            if (i > 1)
            {
                i--;
            }
            
            else
            {
                optionsCanvas.SetActive(true);
                iCanvas.SetActive(false);
                htpCanvas.SetActive(false);
                i = 0;         
            }
            
            Debug.Log(i);
        }

        public void btnRight()
        {
            if (i < 4)
            {
                i++;
            }
            
            else
            {
                optionsCanvas.SetActive(true);
                iCanvas.SetActive(false);
                htpCanvas.SetActive(false);
                i = 0;              
            }

            Debug.Log(i);
        }


//////////

    public void discord()
    {
        Application.OpenURL("https://discord.com/invite/TP2PMbENQS");
    }

    public void instagram()
    {
        Application.OpenURL("https://www.instagram.com/dijitaltasarimcilartoplulugu/");
    }

    public void btnTabiki()
    {
        
    }

    public void btnSanane()
    {

    }


 
   
    // game scenes
    
    public void pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        carCloneObj.SetActive(false);
    }

    /*public void firstPlay()
    {
        Time.timeScale = 0;
        howtoplayPanel.SetActive(true);
        carCloneObj.SetActive(false);
    }*/
    

    public void resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        carCloneObj.SetActive(true);
    }

    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
        Time.timeScale = 1;
    }

    public void quit()
    {
        Debug.Log("Quit Game");
        Application.Quit();     
    }

    
}
