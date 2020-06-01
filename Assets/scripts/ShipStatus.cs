using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipStatus : MonoBehaviour
{
    public int ScorePointsOnDeath = -10;
    public bool IsAllive = true;
    public bool ReloadLevelOnDeath = false;
    public float DefaultLocalPositionX;
    public float DefaultLocalPositionY;
    public float DefaultLocalPositionZ;

    private void Start()
    {
        Transform CurrentTransform = gameObject.GetComponent<Transform>();
        DefaultLocalPositionX = CurrentTransform.localPosition.x;
        DefaultLocalPositionY = CurrentTransform.localPosition.y;
        DefaultLocalPositionZ = CurrentTransform.localPosition.z;
    }
}
