using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfAfterFinish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Destroy(gameObject, ps.main.duration * 1.1f);

    }


}
