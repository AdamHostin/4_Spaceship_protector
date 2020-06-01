using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollisionHandler : MonoBehaviour
{
    [SerializeField] float DeathDelay = 2f;
    #pragma warning disable 0649 //Field 'ShipCollisionHandler.ExplosionFXPrefab' is never assigned to, and will always have its default value null
    [SerializeField] GameObject ExplosionFXPrefab;
    #pragma warning disable 0649
    private bool IsExploded = false;

    private void OnCollisionEnter(Collision collision)
        
    {
        //GameObject explosionGameObj;
        ShipStatus shipStatus = GetComponent<ShipStatus>();
        
        shipStatus.IsAllive = false;
        print("collided");
        if (!IsExploded)
        {
            Explode();
        }
        
        Invoke("ReloadScene", DeathDelay);
    }

    private void Explode()
    {
        GameObject ExplosionFX = Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
        //ExplosionFX.transform.parent = transform;
        ExplosionFX.SetActive(true);
        IsExploded = true;
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
