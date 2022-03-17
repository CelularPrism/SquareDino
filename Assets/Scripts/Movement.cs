using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public bool isMove = false;
    public float speedRotation = 5f;

    private WayPoint wayPoint;
    private NavMeshAgent meshAgent;

    private void Start()
    {
        meshAgent = transform.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (wayPoint != null)
        {
            if (Vector3.Distance(transform.position, wayPoint.position) > 0.1f)
            {                
                isMove = true;
            } else
            {
                isMove = false;
                wayPoint = null;
            }
        }
    }

    public void SetPoint(WayPoint wayPoint)
    {
        this.wayPoint = wayPoint;
        meshAgent.destination = wayPoint.position;
    }
}
