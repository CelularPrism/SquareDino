using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowEnemies : MonoBehaviour
{
    [SerializeField] private Transform enemy;
    void Update()
    {
        if (enemy != null)
            transform.position = new Vector3 (enemy.position.x, transform.position.y, enemy.position.z);
    }
}
