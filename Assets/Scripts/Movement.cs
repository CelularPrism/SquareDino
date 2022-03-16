using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool isMove = false;
    public float speedRotation = 5f;

    private WayPoint wayPoint;

    void Update()
    {
        if (wayPoint != null)
        {
            if (transform.position != wayPoint.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, wayPoint.position, wayPoint.speed * Time.deltaTime);
                transform.LookAt(wayPoint.transform);
                
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
    }
}
