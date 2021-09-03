using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bline : MonoBehaviour
{

    public GameObject sag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(sag.transform.position.x, sag.transform.position.y, sag.transform.position.z +10);

        //Destroy(gameObject,3);
    }
}
