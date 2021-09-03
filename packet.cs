using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packet : MonoBehaviour
{
    public GameObject speedControl;
    
    void Start()
    {
        Destroy(gameObject,2);
    }

    
    void Update()
    {
        transform.Translate(0, 0, 5 * Time.deltaTime);
    }
}
