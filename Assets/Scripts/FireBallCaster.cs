using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public FireBall FireBallPrefab;
    public Camera CameraLink;
    public Transform TargetPosition;

    public float TargetInSkyDistance;

    void Update()
    {
        var ray = CameraLink.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            TargetPosition.position = hit.point;
        }
        else
        {
            TargetPosition.position = ray.GetPoint(TargetInSkyDistance);
        }

        transform.LookAt(TargetPosition);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(FireBallPrefab, transform.position, transform.rotation);
        }
    }
}
