using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject EndText;

    private void Update()
    {
        var enemyHealth = GetComponent<EnemyHealth>();

        if (enemyHealth.Health <= 0)
        {
            Ending();
        }
    }

    public void Ending()
    {
        EndText.SetActive(true);
    }
}
