using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Camera CameraLink;
    public float Force = 10;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var Grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
            Grenade.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * Force * 250);
        }
    }
}
