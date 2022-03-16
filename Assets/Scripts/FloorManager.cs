using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private Transform enemies;

    public bool haveEnemies;

    void Update()
    {
        if (enemies.childCount > 0)
        {
            haveEnemies = true;
        }
        else
        {
            transform.gameObject.layer = LayerMask.NameToLayer("Default");
            haveEnemies = false;
        }
    }

    public Transform GetEnemyField()
    {
        return enemies;
    }
}
