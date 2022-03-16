using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int Health = 3;
    public bool isLive = true;
    public void Damage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            isLive = false;
            //Destroy(transform.gameObject);
        }
    }
}
