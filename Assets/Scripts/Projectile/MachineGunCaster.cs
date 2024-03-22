using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MachineGunCaster : MonoBehaviour
{
    public GameObject MachineGunBulletPrefab;
    public GameObject ShotEffect;
    public Camera CameraLink;
    public Transform TargetPosition;
    public Image RechargeImage;

    public float TimerTime;
    public float TargetInSkyDistance;

    private float Timer;

    private void Start()
    {
        LockCursor();
    }

    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.55f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            TargetPosition.position = hit.point + 10 * CameraLink.transform.forward;
        }
        else
        {
            TargetPosition.position = ray.GetPoint(TargetInSkyDistance);
        }

        transform.LookAt(TargetPosition);

        if (Timer > 0)
        {
            Timer -= 1 * Time.deltaTime;
        }

        RechargeImage.fillAmount = 1 - Timer / TimerTime;

        if (Input.GetMouseButton(0) && Timer <= 0)
        {
            Timer = TimerTime;

            Instantiate(MachineGunBulletPrefab, transform.position, transform.rotation);
            Instantiate(ShotEffect, transform.position, transform.rotation, gameObject.transform);
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
