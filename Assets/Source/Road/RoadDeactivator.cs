using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadDeactivator : MonoBehaviour
{
    [Inject] private RoadManager roadManager;

    private void OnTriggerEnter(Collider other)
    {
        Road roadPiece = other.GetComponent<Road>();
        if (roadPiece != null)
        {
            roadManager.DeactivateRoad(other.gameObject);
        }
        
        if(other.gameObject.GetComponent<StartRoad>())
        {
            Destroy(other.gameObject);
        }
    }
}
