using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Enemy_Behavior : MonoBehaviour
{
    #pragma warning disable 0649 //Field 'ShipCollisionHandler.ExplosionFXPrefab' is never assigned to, and will always have its default value null
    [SerializeField] GameObject ExplosionFXPrefab;
#pragma warning disable 0649

    [SerializeField] int ScorePointsOnDeath = 5;
    [SerializeField] float Delay = 1.5f;
    private ParticleSystem ExplosionParticles;
    private bool IsAllive = true;

    // Start is called before the first frame update
    private void OnParticleCollision(GameObject other)
    {
        if (!IsAllive) return;

        IsAllive = false;

        DestroyChildrenCollider();
        IncreasePlayerScore(ScorePointsOnDeath);
        Exploade();
        Invoke("DestroyEnemy", Delay);
        
    }
    private void Exploade()
    {
        GameObject ExplosionFX = Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
        ExplosionFX.transform.localScale = new Vector3(2, 2, 2);
        ExplosionFX.SetActive(true);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    private void DestroyChildrenCollider()
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
            collider.enabled = false;
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void IncreasePlayerScore(int ScoreChange)
    {
        GameObject.Find("CurrentPlayerScore").GetComponent<ScoreBehavior>().ChangeScore(ScoreChange);
    }

}
