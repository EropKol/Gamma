using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.UI;

public class ShotGuyAI : MonoBehaviour
{
    public List<Transform> TargetPoints;
    public PlayerController Player;
    public float ViewAngle;
    public float Damage = 30;

    public float AttackDistance;
    public float TimerTime;
    public float ShotCount;
    public float Spread;
    public float SpreadAngle;

    public Animator EnemyAnim;

    public GameObject ShotGunBulletPrefab;
    public GameObject ShotEffect;

    public Transform Target;
    public Transform Source;

    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private PlayerHealth _playerHealth;
    private float _timer;
    private float _speed;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        _playerHealth = Player.GetComponent<PlayerHealth>();

        PointUpdate();

        _speed = _navMeshAgent.speed;
    }

    private void Update()
    {
        NoticePlayerUpdate();

        ChooseUpdate();

        _timerUpdate();
    }

    void _timerUpdate()
    {
        if (_timer > 0)
        {
            _timer -= 1 * Time.deltaTime;
        }
    }

    private void NoticePlayerUpdate()
    {
        _isPlayerNoticed = false;

        if (_playerHealth.Health > 0)
        {
            var direction = Player.transform.position - transform.position;
            if (Vector3.Angle(transform.forward, direction) < ViewAngle)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position + Vector3.up + 10 * Vector3.Project(transform.forward, direction), direction, out hit))
                {
                    if (hit.collider.gameObject == Player.gameObject)
                    {
                        _isPlayerNoticed = true;
                        Target.position = hit.point;
                    }
                }
            }
        }
    }

    private void PointUpdate()
    {
        _navMeshAgent.destination = TargetPoints[Random.Range(0, TargetPoints.Count)].position;
    }

    private void ChooseUpdate()
    {
        if (_isPlayerNoticed || _navMeshAgent.speed == 0)
        {
            AttackDamage();
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

    public void AttackDamage()
    {
        {
            if (_navMeshAgent.remainingDistance <= AttackDistance)
            {
                _navMeshAgent.speed = 0;
                EnemyAnim.SetFloat("Speed", 0);

                transform.LookAt(Player.transform);

                if (_timer <= 0)
                {
                    Shoot();

                    _timer = TimerTime;
                }


            }
            else
            {
                _navMeshAgent.speed = _speed;
                EnemyAnim.SetFloat("Speed", 1);
            }
        }
    }

    void Shoot()
    {

        for (int i = 0; i < ShotCount; i++)
        {
            var Pos = new Vector3(Source.position.x + Random.Range(-1f, 1f) * Spread, Source.position.y + Random.Range(-1f, 1f) * Spread, Source.position.z + Random.Range(-1f, 1f) * Spread);
            var Rot = Quaternion.Euler(Random.Range(-1f, 1f) * SpreadAngle, Random.Range(-1f, 1f) * SpreadAngle, Random.Range(-1f, 1f) * SpreadAngle);

            Instantiate(ShotGunBulletPrefab, Pos, Source.rotation * Rot);
        }

        Instantiate(ShotEffect, Source.transform.position, Source.transform.rotation, Source.transform);
    }
}