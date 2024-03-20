using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKitSpawner : MonoBehaviour
{
    public AidKit AidKitPrefab;
    public float Delay = 3; 

    private AidKit _aidKit;

    private void Update()
    {
        if(_aidKit == null)
        {
            if (!IsInvoking())
            {
                Invoke("CreateAidKit", Delay);
            }
        }
    }

    void CreateAidKit()
    {
        _aidKit = Instantiate(AidKitPrefab, gameObject.transform.position, gameObject.transform.rotation);
    }
}
