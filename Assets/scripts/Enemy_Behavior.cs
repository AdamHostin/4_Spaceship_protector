using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    
public class Enemy_Behavior : MonoBehaviour
{
    #pragma warning disable 0649 //Field 'ShipCollisionHandler.ExplosionFXPrefab' is never assigned to, and will always have its default value null
    [SerializeField] GameObject ExplosionFXPrefab;
#pragma warning disable 0649
    [SerializeField] int FullHealth = 100;
    [SerializeField] int ScorePointsOnDeath = 5;
    [SerializeField] float Delay = 1.5f;

    private ParticleSystem ExplosionParticles;
    private int CurrentHealth;

    private void Start()
    {
        CurrentHealth = FullHealth;
    }
    private void OnParticleCollision(GameObject other)
    {
        int Damage = GetDamageValue(other);
        CurrentHealth -= Damage;
        if (CurrentHealth>0) return;

        DestroyChildrenCollider();              
        IncreasePlayerScore(ScorePointsOnDeath);
        Exploade();

        Invoke("DestroyEnemy", Delay);
        
    }
    private int GetDamageValue(GameObject Projectile)
    {
        int Damage;
        WeaponStatus AttackersWeapon = Projectile.GetComponent<WeaponStatus>();
        if(AttackersWeapon != null)
        {
            Damage = AttackersWeapon.DamagePerHit;
        }
        else
        {
            print("Unknown Origin of Damage");
            Damage = 50;
        }
       
        return Damage;
    }


    private void Exploade()
    {
        //Create and acitvate instance of an Explosion
        GameObject ExplosionFX = Instantiate(ExplosionFXPrefab, transform.position, Quaternion.identity);
        ExplosionFX.transform.localScale = new Vector3(2, 2, 2);
        ExplosionFX.SetActive(true);

        //Make Enemy look like it is falling 
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    //Destroy all colliders on object to avoid collision with player during death sequence
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
