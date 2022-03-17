using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private Transform enemies;
    [SerializeField] private GameObject panelHealth;

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
            panelHealth.SetActive(false);
        }
    }

    public void ActivateEnemies()
    {
        foreach (Transform enemyTrans in enemies)
        {
            Enemy enemy = enemyTrans.GetComponent<Enemy>();
            enemy.enabled = true;
        }
        panelHealth.SetActive(true);
    }

    public Transform GetEnemyField()
    {
        return enemies;
    }
}
