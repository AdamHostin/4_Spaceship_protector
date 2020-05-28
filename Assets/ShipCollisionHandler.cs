using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollisionHandler : MonoBehaviour
{
    [SerializeField] float DeathDelay = 2f;


    // depends on kinematic setting in players ship rigidebody
    private void OnCollisionEnter(Collision collision)
        
    {
        //GameObject explosionGameObj;
        ShipStatus shipStatus = GetComponent<ShipStatus>();
        ParticleSystem explosionParticles = GameObject.Find("explosion").GetComponent<ParticleSystem>();
        shipStatus.IsAllive = false;
        explosionParticles.Play();
        print("collided");

        Invoke("ReloadScene", DeathDelay);
    }

    private void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        print("som FOG");
    }
}
