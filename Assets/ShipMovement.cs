using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        float HorizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        print("Horizontal throw: " + HorizontalThrow *Time.deltaTime*TurnSpeed);
        float VerticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        print("Vertical throw: " + VerticalThrow * Time.deltaTime*TurnSpeed);
    }
}
