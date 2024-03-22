using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public float LifeTime = 10;

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
        if (enemyHealth != null)
        {
            enemyHealth.DealDamage(Damage);
        }
    }

    void DestroyFireball()
    {
        Destroy(gameObject);
    }

    void MoveFixedUpdate()
    {
        transform.position += transform.forward * Speed * Time.fixedDeltaTime;
    }
}
