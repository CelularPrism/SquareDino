using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage;
    private Vector3 posPoint;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posPoint, speed * Time.deltaTime);
        if (Physics.CheckBox(transform.position, transform.localScale, transform.rotation, enemyMask))
        {
            Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale, transform.rotation, enemyMask);
            HealthSystem healthSystem = colliders[0].transform.GetComponent<HealthSystem>();
            healthSystem.Damage(damage);
            Destroy(transform.gameObject);
        }
        else if (transform.position == posPoint)
            Destroy(transform.gameObject);
    }

    public void SetPosTouch(Vector3 point)
    {
        posPoint = point;
    }
}