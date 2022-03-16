using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private WayPoint[] wayPoints;
    [SerializeField] private LayerMask floor;

    private int indexPoint;
    private Movement movement;

    private void Start()
    {
        indexPoint = 0;
        movement = transform.GetComponent<Movement>();
    }

    void Update()
    {
        if (!movement.isMove && indexPoint < wayPoints.Length)
        {
            movement.SetPoint(wayPoints[indexPoint]);
            indexPoint++;
        }
    }
}
