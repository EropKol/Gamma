using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShotGunCaster : MonoBehaviour
{
    public GameObject ShotGunBulletPrefab;
    public GameObject ShotEffect;
    public Camera CameraLink;
    public Transform TargetPosition;
    public Image RechargeImage;

    public float TimerTime;
    public float TargetInSkyDistance;
    public float ShotCount;
    public float Spread;
    public float SpreadAngle;

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

        if (Input.GetMouseButtonDown(0) && Timer <= 0)
        {
            Timer = TimerTime;

            for (int i = 0; i < ShotCount; i++)
            {
                var Pos = new Vector3(transform.position.x + Random.Range(-1f, 1f) * Spread, transform.position.y + Random.Range(-1f, 1f) * Spread, transform.position.z + Random.Range(-1f, 1f) * Spread);
                var Rot = Quaternion.Euler(Random.Range(-1f, 1f) * SpreadAngle, Random.Range(-1f, 1f) * SpreadAngle, Random.Range(-1f, 1f) * SpreadAngle);

                Instantiate(ShotGunBulletPrefab, Pos, transform.rotation * Rot);
            }
            
            Instantiate(ShotEffect, transform.position, transform.rotation, gameObject.transform);
        }
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
