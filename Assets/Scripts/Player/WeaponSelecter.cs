using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelecter : MonoBehaviour
{
    public GameObject Weapons;
    public GameObject Weapon1;
    public GameObject Weapon2;
    public GameObject Weapon3;
    public GameObject Weapon4;

    public RectTransform Selection;

    public GameObject Two;
    public GameObject Three;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Weapon1.SetActive(true);
            Weapon4.SetActive(true);


            Weapon2.SetActive(false);
            Weapon3.SetActive(false);

            Selection.localPosition = new Vector3(1.25f, -2.5f);
        }

        if (Input.GetKey(KeyCode.Alpha2) && Two.activeInHierarchy)
        {
            Weapon2.SetActive(true);

            Weapon1.SetActive(false);

            Weapon3.SetActive(false);
            Weapon4.SetActive(false);


            Selection.localPosition = new Vector3(2f, -2.5f);
        }


        if (Input.GetKey(KeyCode.Alpha3) && Three.activeInHierarchy)
        {
            Weapon3.SetActive(true);

            Weapon1.SetActive(false);
            Weapon2.SetActive(false);

            Weapon4.SetActive(false);

            Selection.localPosition = new Vector3(2.75f, -2.5f);
        }
    }
}
