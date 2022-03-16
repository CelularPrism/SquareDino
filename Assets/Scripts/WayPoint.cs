using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Vector3 position;
    public float speed;

    private void Start()
    {
        position = transform.position;
    }
}
