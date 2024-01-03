using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public LayerMask detectionLayer;

    void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;

        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, detectionLayer))
            {
                if (hit.transform == player)
                {
                    Debug.Log("Player detected");
                    // Add detection logic here
                }
            }
        }
    }
}
