using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public TMPro.TextMeshProUGUI speedtxt;
    public TMPro.TextMeshProUGUI sigortatxt;
    public int sigorta = 1;
    public float sideSpeed;
    public float speed;
    
    public TMPro.TextMeshProUGUI scoretxt;
    public TMPro.TextMeshProUGUI endscoretxt;
    public float score = 0;
    public float highScore;

    public Transform way1;
    public Transform way2;
    public Transform way3;
    public Transform cameraMain;
    public Transform cargoCar;
    public Transform carDestroy;
    public Transform carDestroy2;
    public Transform HornCube;

    bool buttonClickGas;
    bool buttonClickBreak;
    bool buttonClickHorn;
    bool buttonClickLeft;
    bool buttonClickRight;

    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;

    public AudioSource voice;
    public AudioClip sigortaVoice;
   
    public AudioSource hornVoice;
    public AudioSource brakeVoice;
    public AudioSource gasVoice;
    public AudioSource carIdleVoice;
    public AudioSource carCrashVoice; 
    
    public Transform cargoCarModel; 

    public Transform sol;
    public Transform sag;
    public GameObject bline;
    public ParticleSystem gasParticle;

    public GameObject taPanel;
    public GameObject taPanel2;
    public GameObject goPanel;
    public GameObject packetClone;
    public GameObject carClone;

    public GameObject howtoplayPanel;
    public GameObject carCloneObj;
    public GameObject gameCanvas;
    int i = 0;

    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;

    void Start()
    {       
        gasParticle.Stop();
        //carIdleVoice.Play(); 

        if (PlayerPrefs.HasKey("highScore"))
        {
            Debug.Log(PlayerPrefs.GetFloat("highScore"));
        }

        if (PlayerPrefs.GetFloat("highScore") < 100)
        {
            ogreticiSahne();
        }
        else
        {
            Debug.Log("skor 100 den büyük");
        }
    }

    void ogreticiSahne()
    {

        Time.timeScale = 0;
            howtoplayPanel.SetActive(true);
            carCloneObj.SetActive(false);
            gameCanvas.SetActive(false);
            i = 1;

    }

        public void btnHtpLeft()
        {
            if (i > 1)
            {
                i--;
            }
            
            else
            {
                Time.timeScale = 1;              
                howtoplayPanel.SetActive(false);
                carCloneObj.SetActive(true);
                gameCanvas.SetActive(true);
                i = 0;       
                  
            }
            
            Debug.Log(i);
        }

        public void btnHtpRight()
        {
            if (i < 4)
            {
                i++;
            }
            
            else
            {
                Time.timeScale = 1;              
                howtoplayPanel.SetActive(false);
                carCloneObj.SetActive(true);
                gameCanvas.SetActive(true);
                i = 0;              
            }

            Debug.Log(i);
        }

    
    void Update()
    {
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

        ///////////////////////////////////////////

        controller();
        //AccelerometreMove();

        if (speed > 5)
        {
            score += speed * Time.deltaTime ;
            scoretxt.text = score.ToString("0");
        }

        speedtxt.text = (speed * 10).ToString("0");
        endscoretxt.text = score.ToString("0");
        sigortatxt.text = sigorta.ToString();

        cameraMain.position = new Vector3(cameraMain.transform.position.x, cameraMain.transform.position.y, cargoCar.transform.position.z - 6); 
        carDestroy.position = new Vector3(carDestroy.transform.position.x, carDestroy.transform.position.y, cargoCar.transform.position.z + 28);
        carDestroy2.position = new Vector3(carDestroy2.transform.position.x, carDestroy2.transform.position.y, cargoCar.transform.position.z - 8); 
        HornCube.position = new Vector3(cargoCar.transform.position.x, cargoCar.transform.position.y, cargoCar.transform.position.z + 2); 
       
        if (speed >= 2f && speed < 11f)
        {
            if (Time.timeScale == 1)
            {
                //speed-=0.003f;
                speed += 0.015f;
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-10,0,0), .2f);
            }
            
             
        }

        // buton kontrol için
        if (buttonClickGas)
        {
            if (speed < 11f)
            {
                speed += 0.02f;
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-10,0,0), .2f);
                
                
            }
           /* if (speed > 10.5f && speed < 11f)
            {
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-10,0,0), .2f);
            }      */      
        }
        
        if (buttonClickBreak)
        {
            if (speed >= 2.5f)
            {
                speed -= 0.08f;
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(10,0,0), .2f);   
                
            }      
        }

        if (buttonClickLeft)
        {
            if (transform.position.x > -1.19f)
            {
                transform.position += Vector3.left * sideSpeed *Time.deltaTime;
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,10), .3f);       
            }    
        }
        
        if (buttonClickRight)
        {
            if (transform.position.x < 1.19f)
            {
                transform.position += Vector3.right * sideSpeed *Time.deltaTime;
                cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-10), .3f);
            }
        }
        
    }


    void controller()
    {
        // araç kontol  

        transform.position += Vector3.forward * speed *Time.deltaTime;
        //cargoCarModel.transform.rotation = Quaternion.Euler(0,0,0);  // keskin dönüş için
        cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), .3f); // yumuşak dönüş için

        // klavye ile kontrol

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 1.19f)
        {
            transform.position += Vector3.right * sideSpeed *Time.deltaTime;
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-10), .3f);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -1.19f)
        {
            transform.position += Vector3.left * sideSpeed *Time.deltaTime;
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,10), .3f);       
        }

        if (Input.GetKey(KeyCode.UpArrow) && speed < 11f)
        {
            speed += 0.02f;
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-10,0,0), .3f);
        }
       
        if (Input.GetKey(KeyCode.DownArrow) && speed >= 2.5f)
        {
            speed -= 0.08f;
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(10,0,0), .3f);
      
        }

    }

    void AccelerometreMove()
    {
        //android kontrol
        
        float posX = Input.acceleration.x;

        if (posX > 0.1f && transform.position.x < 1.19f)
        {
            transform.position += Vector3.right * sideSpeed *Time.deltaTime; 
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,-10), .3f);
        }

        if (posX < -0.1f && transform.position.x > -1.19f)
        {
            transform.position += Vector3.left * sideSpeed *Time.deltaTime;
            cargoCarModel.transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,10), .3f);
        }

    }

    public void btnGas()
    {
        buttonClickGas = true;
        gasParticle.Play();
        gasVoice.Play();
    }

    public void btnBreak()
    {
        buttonClickBreak = true;
        brakeVoice.Play();             
    }

    public void btnHorn()
    {
        hornVoice.Play();
        buttonClickHorn = true;     
    }


    ////  gameplay 1

    public void btnLeft()
    {
        buttonClickLeft = true;
    }
    public void btnRight()
    {
        buttonClickRight = true;     
    }

    public void nullbuton()
    {
        buttonClickGas = false;
        buttonClickBreak = false;
        buttonClickHorn = false;
        buttonClickLeft = false;
        buttonClickRight = false;
        
        gasParticle.Stop();        
        hornVoice.Stop(); 
        brakeVoice.Stop();
        gasVoice.Stop();
    }



    private void OnCollisionEnter(Collision other) 
    {
        // çarpışma kontrol

        if (other.gameObject.tag == "car")
        {
            if (sigorta > 0)
            {
                Time.timeScale = 0; 
                speed = 2;
                Destroy(other.gameObject);
                sigorta -= 1;
                sigortatxt.text = sigorta.ToString();
                score -= 100;
                carCrashVoice.Play();
                taPanel.SetActive(true);
                packetClone.SetActive(false);
                carClone.SetActive(false);

                //taPanel.SetActive(true);
                //game paused                       
            }
            
            else
            {
                //Debug.Log("game over for Car");
                //Debug.Log(PlayerPrefs.GetFloat("highScore"));               
                Time.timeScale = 0; 
                goPanel.SetActive(true);
                carIdleVoice.Stop(); 
                carCrashVoice.Play();
                
                // high score kaydetme

                if (score > PlayerPrefs.GetFloat("highScore"))
                {
                    highScore = score;
                    PlayerPrefs.SetFloat("highScore",highScore);                  
                }
            }            
        }

       
    }

    public void btnTAgain()
    {
        Time.timeScale = 1;
        taPanel.SetActive(false);
        carIdleVoice.Play(); 
        packetClone.SetActive(true);
        carClone.SetActive(true);
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    public void btnNoTAgain()
    {
        taPanel2.SetActive(false);
        taPanel.SetActive(false); 
        goPanel.SetActive(true);
        //carIdleVoice.Stop(); 
        //carCrashVoice.Play();
                
            // high score kaydetme
        if (score > PlayerPrefs.GetFloat("highScore"))
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore",highScore);
                    
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        // sonsuz yol 

        if (other.gameObject.name == "wall1")
        {
           way3.position = new Vector3(way2.transform.position.x, way2.transform.position.y, way2.position.z + 20);
        }
        
        if (other.gameObject.name == "wall2")
        {
           way1.position = new Vector3(way1.transform.position.x, way1.transform.position.y, way3.position.z + 20);
        }

        if (other.gameObject.name == "wall3")
        {
           way2.position = new Vector3(way2.transform.position.x, way2.transform.position.y, way1.position.z + 20);
        }
           
        // sigorta 

        if (other.gameObject.name == "sigorta(Clone)") 
        {
            voice.PlayOneShot(sigortaVoice);
            Destroy(other.gameObject);
            
            if (sigorta < 1)
            {                            
                sigorta += 1;
                sigortatxt.text = sigorta.ToString();
                score += 50;                               
            }
            else
            {
                score += 100;
            }        
        }      
    }


    void creatBrakeLine()
    {
        Instantiate(bline, new Vector3(sag.transform.position.x, sag.transform.position.y, sag.transform.position.z), Quaternion.identity);
        //Instantiate(bline, new Vector3(sol.transform.position.x, sol.transform.position.y, sol.transform.position.z), Quaternion.identity);
        //this.gameObject.position = (sag.transform.position.x, sag.transform.position.y, sag.transform.position.z);
    }

    void gamePause()
    {
        Time.timeScale = 0;         
    }
    

}