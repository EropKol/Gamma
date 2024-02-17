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

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        PointUpdate();
    }

    private void Update()
    {
        NoticePlayerUpdate();

        ChooseUpdate();
    }

    private void NoticePlayerUpdate()
    {
        var direction = Player.transform.position - transform.position;
        _isPlayerNoticed = false;
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

    private void PointUpdate()
    {
        _navMeshAgent.destination = TargetPoints [Random.Range(0, TargetPoints.Count)].position;
    }

    private void ChooseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = Player.transform.position;
        }
        else
        {
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                PointUpdate();
            }
        }            
    }
}
