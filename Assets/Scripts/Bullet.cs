using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private float speed = 5f;
    private Vector3 posPoint;

    private int damage;

    private void Start()
    {
        damage = 2;
    }

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
        else if (Vector3.Distance(transform.position, posPoint) <= 0.001f)
            Destroy(transform.gameObject);
    }

    public void SetPosTouch(Vector3 point)
    {
        posPoint = point;
    }
}