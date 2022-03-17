using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public bool isMove = false;

    private Vector3 positionWayPoint;
    private NavMeshAgent meshAgent;

    private void Start()
    {
        meshAgent = transform.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (positionWayPoint != Vector3.zero)
        {
            if (Vector3.Distance(transform.position, positionWayPoint) > 0.1f)
            {
                isMove = true;
            } else
            {
                isMove = false;
                positionWayPoint = Vector3.zero;
            }
        }
    }

    public void SetPoint(Vector3 wayPoint, float speed)
    {
        positionWayPoint = wayPoint;
        meshAgent.destination = wayPoint;
        meshAgent.speed = speed;
    }
}
