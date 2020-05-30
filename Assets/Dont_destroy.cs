using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_destroy : MonoBehaviour
{
    
    void Awake()
    {
        if((FindObjectsOfType(this.GetType()).Length) >1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }


}
