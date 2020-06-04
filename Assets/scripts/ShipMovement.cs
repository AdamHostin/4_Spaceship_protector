using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovement : MonoBehaviour
{
    [Header("General")]
    [SerializeField] float TurnSpeed = 20f;
    
    [Header("Movement restriction")]
    [SerializeField] float UpperRestriction = 12f;
    [SerializeField] float LowerRestriction = -12f;
    [SerializeField] float LeftRestriction = -22f;
    [SerializeField] float RightRestriction = 22f;
    [Header("Rotations")]
    [SerializeField] float XRotateValue = -1.35f;
    [SerializeField] float YRotateValue = 1.5f;
    [SerializeField] float ThrowRotateValue = -20f;
    [Header("LaserGuns")]
    [SerializeField] GameObject[] LaserGuns;

    
    float HorizontalThrow = 0f;
    float VerticalThrow = 0f;
    private bool IsShooting = false;

    void Update()
    {
        ShipStatus shipStatus = GetComponent<ShipStatus>();
        if (!shipStatus.IsAllive) return;
        UpdateLocalPosition();
        UpdateLocalRotate();
        UpdateFire();
    }

    private void UpdateFire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
        {
            if (!IsShooting)
            {
                EnableWeapons();
                IsShooting = true;
            }

        }
        else
        {
            if (IsShooting)
            {
                DisableWeapons();
                IsShooting = false;
            }
            
        }
    }

    private void DisableWeapons()
    {
        foreach (GameObject LaserGun in LaserGuns)
        {
            LaserGun.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void EnableWeapons()
    {
        foreach (GameObject LaserGun in LaserGuns)
        {
            LaserGun.GetComponent<ParticleSystem>().Play();
        }
    }

    private void UpdateLocalRotate()
    {
        float FutureXRotation = transform.localPosition.y * XRotateValue + VerticalThrow * (ThrowRotateValue);
        float FutureYRotation = transform.localPosition.x * YRotateValue;
        float FutureZRotation = HorizontalThrow * ThrowRotateValue;
        transform.localRotation = Quaternion.Euler(FutureXRotation,FutureYRotation,FutureZRotation);
    }

    private void UpdateLocalPosition()
    {
        HorizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float HorizontalOffset = HorizontalThrow * Time.deltaTime * TurnSpeed;

        VerticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float VerticalOffset = VerticalThrow * Time.deltaTime * TurnSpeed;

        float FutureXPosition = HorizontalOffset + transform.localPosition.x;
        float FutureYPosition = VerticalOffset + transform.localPosition.y;


        transform.localPosition = new Vector3(Mathf.Clamp(FutureXPosition, LeftRestriction, RightRestriction),
                                              Mathf.Clamp(FutureYPosition, LowerRestriction, UpperRestriction),
                                              transform.localPosition.z);
    }
    
}