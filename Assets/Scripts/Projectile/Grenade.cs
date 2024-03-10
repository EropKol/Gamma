using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float Delay = 3;
    public GameObject ExplosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", Delay);
    }
    
    void Explosion()
    {
        Destroy(gameObject);
        Instantiate(ExplosionPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
