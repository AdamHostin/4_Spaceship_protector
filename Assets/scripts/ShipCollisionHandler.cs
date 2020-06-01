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

    

    private void OnCollisionEnter(Collision collision)
        
    {
        //GameObject explosionGameObj;
        ShipStatus shipStatus = GetComponent<ShipStatus>();



        if (!shipStatus.IsAllive) return;
        
        Explode();
        shipStatus.IsAllive = false;
        
        Invoke("ReloadScene", DeathDelay);
        
        
        
    }

    private void Explode()
    {
        GameObject ExplosionFX = Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
        //ExplosionFX.transform.parent = transform;
        ExplosionFX.SetActive(true);

    }   

    private void ReloadScene()
    {
        ShipStatus shipStatus = GetComponent<ShipStatus>();
        if (shipStatus.ReloadLevelOnDeath)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        else
        {
            DecreasePlayerScore(shipStatus.ScorePointsOnDeath);
            GameObject.Find("Main Camera").GetComponent<Respawn>().RespawnSelf();
            shipStatus.IsAllive = true;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        print("som FOG");
    }

    private void DecreasePlayerScore(int ScoreChange)
    {
        GameObject.Find("CurrentPlayerScore").GetComponent<ScoreBehavior>().ChangeScore(ScoreChange);
    }

}

