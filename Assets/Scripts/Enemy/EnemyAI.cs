using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> TargetPoints;
    public PlayerController Player;
    public float VievAngle;
    public float Damage = 30;
    public float AttackDistanse = 1;

    public Animator EnemyAnim;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _playerHealth = Player.GetComponent<PlayerHealth>();

        PointUpdate();
    }

    private void Update()
    {
        NoticePlayerUpdate();

        ChooseUpdate();
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;

        if (_playerHealth.Health > 0)
        {
            var direction = Player.transform.position - transform.position;
            if (Vector3.Angle(transform.forward, direction) < VievAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
                {
                    if (hit.collider.gameObject == Player.gameObject)
                    {
                        _isPlayerNoticed = true;
                    }
                }
            }
        }
    }

    private void PointUpdate()
    {
        _navMeshAgent.destination = TargetPoints [Random.Range(0, TargetPoints.Count)].position;
    }

    private void ChooseUpdate()
    {
        if (_isPlayerNoticed)
        {
            AttackUpdate();
            _navMeshAgent.destination = Player.transform.position;
        }
        else
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PointUpdate();
            }
        }            
    }

    void AttackUpdate()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
        {
            EnemyAnim.SetTrigger("Attack");
        }
    }

    public void AttackDamage()
    {
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance + AttackDistanse)
            {
                _playerHealth.DealDamage(Damage);
            }
        }
    }
}
