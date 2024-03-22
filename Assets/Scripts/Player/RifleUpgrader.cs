using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleUpgrader : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Rifle2;

    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            Rifle.SetActive(false);
            Rifle2.SetActive(true);

            Destroy(gameObject);
        }
    }
}
