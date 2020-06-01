using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyMusicPlayer : DontDestroyThis
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyThisObject();
    }


}
