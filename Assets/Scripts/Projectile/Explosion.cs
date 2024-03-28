using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Damage = 50;
    public float MaxSize = 5;
    public float Speed = 2;

    public ParticleSystem ExplosionEffect;

    private void Start()
    {
        transform.localScale = Vector3.zero;
    }

    private void Update()
    {
        transform.localScale += Vector3.one * Time.deltaTime * Speed;

        SizeUpdate();
    }

    private void SizeUpdate()
    {
        if(transform.localScale.x >= MaxSize)
        {
            Destroy(gameObject);
            Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null )
        {
            playerHealth.DealDamage(Damage);
        }

        var enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null )
        {
            enemyHealth.DealDamage(Damage);
        }

        var ShotGuyHealth = other.GetComponent<ShotGuyHealth>();
        if (ShotGuyHealth != null)
        {
            ShotGuyHealth.DealDamage(Damage);
        }
    }
}
