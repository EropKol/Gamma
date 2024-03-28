using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUnlocker : MonoBehaviour
{
    public GameObject Unlockable;
    public GameObject UIUnlock;

    private void OnTriggerEnter(Collider other)
    {
        var PlayerHealth = other.gameObject.GetComponent<PlayerHealth>();
        if (PlayerHealth != null)
        {
            Unlockable.SetActive(true);
            UIUnlock.SetActive(true);

            Destroy(gameObject);
        }
    }
}
