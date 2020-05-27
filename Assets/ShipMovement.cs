using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 5f;
    [SerializeField] float UpperRestriction = 12f;
    [SerializeField] float LowerRestriction = -12f;
    [SerializeField] float LeftRestriction = -20f;
    [SerializeField] float RightRestriction = 20f;
    [SerializeField] float XRotateValue = -1.35f;
    [SerializeField] float YRotateValue = 1f;
    [SerializeField] float ThrowRotateValue = 10f;

    float HorizontalThrow = 0f;
    float VerticalThrow = 0f;

    void Update()
    {
        UpdateLocalPosition();
        UpdateLocalRotate();
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