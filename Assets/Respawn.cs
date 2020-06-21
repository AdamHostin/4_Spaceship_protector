using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    [SerializeField] float Delay = 1.5f;

    public void RespawnSelf()
    {

        Invoke("LoadScene", Delay);
    }

    void LoadScene()
    {

        SceneManager.LoadScene(1);
    }
}
