using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public Transform Target;

    private void Update()
    {
        transform.LookAt(Target);
    }
}
