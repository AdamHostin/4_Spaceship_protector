using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThis : MonoBehaviour
{

    protected void DontDestroyThisObject()
    {
        print(this.GetType());
        if ((FindObjectsOfType(this.GetType()).Length) > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


}
