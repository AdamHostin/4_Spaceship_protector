using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Leve_load_from_splash : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float Delay = 5.0f;

    void Start()
    {
        Invoke("LoadScene", Delay);
    }

    void LoadScene()
    {
        
        SceneManager.LoadScene(1);
    }
}
