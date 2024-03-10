using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEventScript : MonoBehaviour
{
    public EnemyAI AIEnemy;

    public void AttackEvent()
    {
        AIEnemy.AttackDamage();
    }
}
