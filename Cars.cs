using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : MonoBehaviour
{
   int speed;
   public Transform cargoCar;
   public GameObject carClone;
   float cargoCarPZ2;
   float speeds1 = 5, speeds2 = 7, speeds3 = 6, 
   speedm1 = 5, speedm2 = 4, speedm3 = 4, 
   speedb1= 4, speedb2= 4; 

   bool buttonHorn;

      
   void Start() 
   {
      // cargoCarPZ2 = carClone.GetComponent<carClone>().cargoCarPZ;
   }

   void Update()
   {
      // Debug.Log("CC: "+cargoCarPZ2);       
      //Debug.Log("NC: " + this.gameObject.transform.position);
          
      if (this.gameObject.name == "sCar1(Clone)")
      {
         //speeds = 5;
         transform.position += Vector3.forward * speeds1  *Time.deltaTime;     
         // scarColor1.color = Random.ColorHSV();    
      }
      
      if (this.gameObject.name == "sCar2(Clone)")
      {
         //speeds = 5;
         transform.position += Vector3.forward * speeds2  *Time.deltaTime;
         //scarColor2.color = Random.ColorHSV();           
      }
      
      if (this.gameObject.name == "sCar3(Clone)")
      {
         //speeds = 5;
         transform.position += Vector3.forward * speeds3  *Time.deltaTime;
         //scarColor2.color = Random.ColorHSV();           
      }

      //////////////////////////////////////////////////////////////

      if (this.gameObject.name == "mCar1(Clone)")
      {
         // speedm = 4;
         transform.position += Vector3.forward * speedm1 *Time.deltaTime;            
      }
          
      if (this.gameObject.name == "mCar2(Clone)")
      {
         // speedm = 4;
         transform.position += Vector3.forward * speedm2  *Time.deltaTime;            
      }
          
      if (this.gameObject.name == "mCar3(Clone)")
      {
         // speedm = 4;
         transform.position += Vector3.forward * speedm3  *Time.deltaTime;            
      }

      //////////////////////////////////////////////////////////////

      if (this.gameObject.name == "bCar1(Clone)")
      {
         //speedb = 3;
         transform.position += Vector3.forward * speedb1  *Time.deltaTime;            
      }

      if (this.gameObject.name == "bCar2(Clone)")
      {
         //speedb = 3;
         transform.position += Vector3.forward * speedb2  *Time.deltaTime;            
      }      
   }

   private void OnTriggerEnter(Collider other) 
   {     
      if (other.gameObject.tag == "carDestroy")
      {
         Destroy(this.gameObject);             
      }

      if (other.gameObject.tag == "stopCube")
      {
         speeds1 = 4;
         speeds2 = 4;
         speeds3 = 4;

         speedm1 = 4;
         speedm2 = 4;
         speedm3 = 4; 
         //Debug.Log("ol artık amkkk");
      }
           
      if (other.gameObject.tag == "HornCube")
      {  
         Debug.Log("BAS GAZA AŞKM BASS GAZAA");
         
         if (buttonHorn)
         {
            Debug.Log("DÜT DÜT");
               
           /* if (speeds1 == 4 || speeds2 == 4 || speeds3 == 4 ||speedm1 == 4 || speedm2 == 4 ||speedm3 == 4 || speedb1 == 4 || speedb2 == 4)
            {
                  speeds1 = 6;
                  speeds2 = 6;
                  speeds3 = 6;

                  speedm1 = 6;
                  speedm2 = 6;
                  speedm3 = 6;

                  speedb1 = 6;
                  speedb2 = 6;

                  Debug.Log("Basma lan kornaya");                 
            }*/
            
         }
      }
      
   }

   public void btnHorn()
   {
      buttonHorn = true; 
   }

   public void btnNull()
   {
      buttonHorn = false;
   }



}
