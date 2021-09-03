using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenucarClone : MonoBehaviour
{

    public float speed;

    public GameObject sCar1;
    public GameObject sCar2;
    public GameObject sCar3;
    
    public GameObject mCar1;
    public GameObject mCar2;
    public GameObject mCar3;
    
    public GameObject bCar1;
    public GameObject bCar2;

    int i = 0;

    void Start()
    {
        i = Random.Range(0,8);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (transform.position.x > 22f)
        {
            transform.position =  new Vector3(-33.99f, -0.72f, 9.3f);     

             if (i < 8)
             {
                 i++;
             }
             else
             {
                 i = 0;
             }

             //i = Random.Range(0,8);
        }

                if (i == 0)
                {
                    sCar1.SetActive(true);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                }  
                
                if (i == 7)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(true);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                } 
                
                if (i == 2)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(true);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                } 
                
                if (i == 5)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(true);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                } 
                
                if (i == 6)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(true);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                } 
                
                if (i == 3)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(true);

                    bCar1.SetActive(false);
                    bCar2.SetActive(false);
                }  
                if (i == 4)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(true);
                    bCar2.SetActive(false);
                } 
                if (i == 1)
                {
                    sCar1.SetActive(false);
                    sCar2.SetActive(false);
                    sCar3.SetActive(false);

                    mCar1.SetActive(false);
                    mCar2.SetActive(false);
                    mCar3.SetActive(false);

                    bCar1.SetActive(false);
                    bCar2.SetActive(true);
                } 
    }

}
