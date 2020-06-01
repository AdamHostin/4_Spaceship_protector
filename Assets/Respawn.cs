using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class Respawn : MonoBehaviour
{
    public void RespawnSelf()
    {
        
        gameObject.GetComponent<WaypointProgressTracker>().Reset();
        Transform ShipTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        ShipStatus shipStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<ShipStatus>();
        ShipTransform.localPosition = new Vector3(shipStatus.DefaultLocalPositionX,
                                                  shipStatus.DefaultLocalPositionY,
                                                  shipStatus.DefaultLocalPositionZ);
    }
}
