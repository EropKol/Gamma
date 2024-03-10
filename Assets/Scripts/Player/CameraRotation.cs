using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraHolder;
    public float RotationSpeed = 100;
    public float MinAngle;
    public float MaxAngle;

    void Update()
    {
        var NewAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * Time.deltaTime * RotationSpeed;
        transform.localEulerAngles = new Vector3(0, NewAngleY, 0);

        var NewAngleX = CameraHolder.localEulerAngles.x - Input.GetAxis("Mouse Y") * Time.deltaTime * RotationSpeed;
        if (NewAngleX > 180)
            NewAngleX -= 360;
        
        NewAngleX = Mathf.Clamp(NewAngleX, MinAngle, MaxAngle);

        CameraHolder.localEulerAngles = new Vector3(NewAngleX, 0, 0);
    }
}
