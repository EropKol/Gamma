using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float Speed;
    public float LifeTime = 10;

    public float Damage = 10;

    private void Start()
    {
        Invoke("DestroyFireball", LifeTime);
    }

    void FixedUpdate()
    {
        MoveFixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)
    {
        IfEnemy(collision);

        DestroyFireball();
    }

    void IfEnemy(Collision collision)
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
