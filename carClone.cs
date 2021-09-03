using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carClone : MonoBehaviour
{

    public Transform cargoCar;
    public GameObject dosigo;
    
    public GameObject sCar1;
    public GameObject sCar2;
    public GameObject sCar3;
    
    public GameObject mCar1;
    public GameObject mCar2;
    public GameObject mCar3;
    
    public GameObject bCar1;
    public GameObject bCar2;
    
    public Material scarColor1;
    public Material scarColor2;

    public float cargoCarPZ;

    void Start() 
    {
        InvokeRepeating("objectclone", 0, 1.7f) ;   
    }
    void Update()
    {
        // spawn olacak araç çeşitleri

        // Debug.Log("CCT: "+cargoCar.transform.position);
        // Debug.Log("CC: "+cargoCarPZ);   
        // cargoCarPZ = cargoCar.transform.position.z;
        
    }

    void objectclone()
    {
        int b = Random.Range(0,100);
        int c = Random.Range(0,3);
        int d = Random.Range(0,2);

        if (b < 30)
        {
            //S-CARS
            if (c == 0)
            {
                clone(sCar1);
            }
            if (c == 1)
            {
                clone(sCar2);
            }
            if (c == 2)
            {
                clone(sCar3);
            }
                       
        }
        
        if (b > 30 && b < 47)
        {
            //M-CARS 
            if (c == 0)
            {
                //scarColor1.color = Random.ColorHSV();
                clone(mCar1);
                
            }
            if (c == 1)
            {
                clone(mCar2);
                //scarColor2.color = Random.ColorHSV();
            }
            if (c == 2)
            {
                clone(mCar3);
                //scarColor1.color = Random.ColorHSV();
            }
        }
        
        if (b > 50 && b < 63)
        {
            //B-CARS
            if (d == 0)
            {
                clone(bCar1);
            }
            if (d == 1)
            {
                clone(bCar2);
            }
            
        }   
        
        if (b > 70 && b < 72)
        {   
            //DOSİGO
            clone(dosigo);
        } 
    }


    void clone(GameObject car)
    {
        //araçlar spawn olma yerleri

        int a = Random.Range(0,3);
        GameObject newclone = Instantiate(car);
        //scarColor.color = Random.ColorHSV();
    

        if (a == 0)
        {
            newclone.transform.position = new Vector3(-1, 0.3f, cargoCar.position.z + 20);             
        }
         
        if (a == 1)
        {
            newclone.transform.position = new Vector3(0, 0.3f, cargoCar.position.z + 20);
        }
         
        if (a == 2)
        {
            newclone.transform.position = new Vector3(1, 0.3f, cargoCar.position.z + 20);
        }
            
        /* if (newclone.transform.position.z < cargoCar.position.z)
        {
            Debug.Log("olur gibi 2");
        }*/

       //  Debug.Log("NC: " + newclone.transform.position);   
        
    }


}
