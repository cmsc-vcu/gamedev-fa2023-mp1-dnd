using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 100;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage);            }
        }
    }
}
