using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public float LifeTime = 10;

    public GameObject Sphere;
    public GameObject Prefab;

    public float Damage = 10;

    private void Start()
    {
        Invoke("DestroyFireball", LifeTime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnTriggerEnter(Collider collision)
    {
        IfEnemy(collision);

        if (!collision.gameObject.CompareTag("Bullet"))
        {
            DestroyFireball();
        }
    }

    void IfEnemy(Collider collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        var shotGuyHealth = collision.gameObject.GetComponent<ShotGuyHealth>();
        var playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
        if (shotGuyHealth != null)
        {
            shotGuyHealth.DealDamage(Damage);
        }
        if (playerHealth != null)
        {
            playerHealth.DealDamage(Damage);
        }
    }

    void DestroyFireball()
    {
        Invoke("RealDestroy", 0.5f);

        Sphere.SetActive(false);
        GetComponent<SphereCollider>().enabled = false;
        enabled = false;
    }

    void RealDestroy()
    {
        Destroy(gameObject);
    }

    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
}
