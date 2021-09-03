using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerOptions : MonoBehaviour
{

    public TMPro.TMP_Dropdown graphDrop;
    public AudioListener menuListener;

    public GameObject camera;
    public GameObject imageON;
    public GameObject imageOFF;
    bool voiceStop = true;

    private void Start() 
    {
        if (PlayerPrefs.HasKey("grapNumber"))
        {
            graphDrop.value = PlayerPrefs.GetInt("grapNumber");
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("grapNumber"));
        }

        else
        {
           PlayerPrefs.SetInt("grapNumber", 2); 
            graphDrop.value =2;
        }

        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        
        UpdateButtonIcon();
        AudioListener.pause = voiceStop;

    }

    public void GrapSetting (int gNum)
    {
        QualitySettings.SetQualityLevel(gNum);
        PlayerPrefs.SetInt("grapNumber", gNum);     
        Debug.Log(gNum);
    }


    public void btnVoice()
    {
        
        if (voiceStop == false)
        {
            //camera.GetComponent<AudioListener>().enabled = !camera.GetComponent<AudioListener> ().enabled;
            AudioListener.pause = true;
            voiceStop = true;
            //imageON.SetActive(false);
            //imageOFF.SetActive(true);

        }
        else 
        {
            //camera.GetComponent<AudioListener>().enabled = !camera.GetComponent<AudioListener> ().enabled;
            AudioListener.pause = false;
            voiceStop = false;
            //imageON.SetActive(true);
            //imageOFF.SetActive(false);

        }

        Debug.Log(voiceStop);
        Save();
        UpdateButtonIcon();
    }
    
    private void UpdateButtonIcon()
    {
        if(voiceStop==false)
        {
            imageON.SetActive(true);
            imageOFF.SetActive(false);
        }
        else
        {
            imageON.SetActive(false);
            imageOFF.SetActive(true);
        }

    }

    private void Load()
    {
        voiceStop = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", voiceStop ? 1 : 0);
    }


}
