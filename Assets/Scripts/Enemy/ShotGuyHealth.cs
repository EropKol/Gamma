using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShotGuyHealth : MonoBehaviour
{
    public float Health = 100;

    public Animator EnemyAnim;

    public GameObject ShotGun;

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
        GetComponent<ShotGuyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;

        var Drop = GetComponent<DropItem>();
        Drop.Drop();

        Destroy(ShotGun);
    }
}
