using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packetClone : MonoBehaviour
{
    public GameObject packet;
    public GameObject packet2;
    public GameObject car;
    // public float cdown;
    public GameObject goPanel;
    public GameObject taPanel;
    public GameObject carClone;
    //public GameObject packetCloneobj;

    public TMPro.TextMeshProUGUI packetstxt;
    public int packets = 10;
    public float waittime = 1;
    
    int x;
    RaycastHit carpma;
    
    public GameObject scorePlus;
    public GameObject sigortaControl;
    public GameObject speedControl;

    public AudioSource voice;
    public AudioClip packetVoice;
    public AudioClip failVoice;

    public float nextCloneTime = 0;
    public float cooldown = 1; 
    

    void Start()
    {
        
    }

    void Update() 
    {
        packetstxt.text = packets.ToString();    
        //Debug.Log(speedControl.GetComponent<Player>().speed);

        if (Time.time > nextCloneTime)
        {
            if (speedControl.GetComponent<Player>().speed > 5)
            {
            x = Random.Range(0,400);
            
            if (x > 395)
            {
                int i = Random.Range(0,3);

                if (i == 1)
                {
                    Instantiate(packet2, new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z- 0.5f), Quaternion.identity);
                    //Debug.Log("YANLIŞ PAKET!!!");
                    nextCloneTime = Time.time + cooldown;
                    
                    
                }
                else
                {
                    Instantiate(packet, new Vector3(car.transform.position.x, car.transform.position.y, car.transform.position.z- 0.5f), Quaternion.identity);
                    packets-=1;
                    nextCloneTime = Time.time + cooldown;
                                       
                }

                         
            }          
        }
            
        }  
              


        if (packets < 0)
        {
            Debug.Log(sigortaControl.GetComponent<Player>().sigorta);
            if (sigortaControl.GetComponent<Player>().sigorta == 1)
            {
                //Debug.Log("gameover");
                Time.timeScale = 0;          
                taPanel.SetActive(true);
                //packetClone.SetActive(false);
                carClone.SetActive(false);
                this.gameObject.SetActive(false);
                speedControl.GetComponent<Player>().speed = 2;
                sigortaControl.GetComponent<Player>().sigorta -=1;
                
            }

            else
            {
                Time.timeScale = 0;          
                goPanel.SetActive(true);
                //packetClone.SetActive(false);
                carClone.SetActive(false);
                this.gameObject.SetActive(false);
                speedControl.GetComponent<Player>().speed = 2;
                
            }        

        }   


        Ray outray = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(outray.origin,outray.direction *10f , Color.red);
        
        if (Physics.Raycast(outray, out carpma))
        {
            if (carpma.collider.gameObject.tag == "Finish" )
            {                        
                //Debug.Log("çarpışma başarılı");
                packets+=1;
                voice.PlayOneShot(packetVoice);
                scorePlus.GetComponent<Player>().score+=50;
                Destroy(carpma.collider.gameObject);                                                        
            }

            if (carpma.collider.gameObject.tag == "Finish2" )
            {                        
                //Debug.Log("çarpışma başarılı");
                packets-=1;
                voice.PlayOneShot(failVoice);
                //corePlus.GetComponent<Player>().score-=50;
                Destroy(carpma.collider.gameObject);
                Debug.Log("-50");                                                        
            }
        }    
    }


    public void btnTAgainPacket()
    {
        Time.timeScale = 1;     
        packets = 6;     
        taPanel.SetActive(false);
        //packetClone.SetActive(false);
        carClone.SetActive(true);
        this.gameObject.SetActive(true);
    }


}
