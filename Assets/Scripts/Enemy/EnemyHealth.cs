using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float Health = 100;

    public Animator EnemyAnim;

    public void DealDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            EnemyDeath();
            // Destroy(gameObject);
        }
        else
        {
            EnemyAnim.SetTrigger("Hit"); 
        }
    }

    private void EnemyDeath()
    {
        EnemyAnim.SetFloat("Death", 1);
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}
