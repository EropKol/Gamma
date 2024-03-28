using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Camera CameraLink;
    public float Force = 10;
    public float Count;
    public GameObject TextObject;


    void Update()
    {

        var TextCount = TextObject.GetComponent<TextMeshProUGUI>();

        TextCount.text = Count.ToString();

        if (Input.GetMouseButtonDown(1) && Count >= 1)
        {
            Count -= 1;

            var Grenade = Instantiate(GrenadePrefab, transform.position, transform.rotation);
            Grenade.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * Force * 250);
        }
    }
}
