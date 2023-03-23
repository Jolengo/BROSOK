using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    Idle,
    WalkToPlayer,
    Attack
} 

public class Enemy : MonoBehaviour
{

    public EnemyState CurrentEnemyState;

    public int Health = 1;
    public GameObject Player;
    public float DistanceToFollow = 7f;

    public NavMeshAgent NavMeshAgent;
    public Animator EnemyAnimator;

    private float _distanceToAttack = 1f;

    private void Start()
    {
        _distanceToAttack = NavMeshAgent.stoppingDistance;
        Player = FindObjectOfType<PlayerMove>().gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!EnemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            FindPlayer();

        Vector3 Direction = Player.transform.position - transform.position;
        Direction.Set(Direction.x, 0f, Direction.z);
        transform.rotation = Quaternion.LookRotation(Direction);

        if (CurrentEnemyState == EnemyState.WalkToPlayer)
        {
            NavMeshAgent.SetDestination(Player.transform.position);
            EnemyAnimator.SetBool("Walk", true);
        }
        if (CurrentEnemyState == EnemyState.Attack)
        {
            EnemyAnimator.SetBool("Attack", true);
        }
    }

    public void SetState(EnemyState enemyState)
    {
        CurrentEnemyState = enemyState;
    }

    public void FindPlayer()
    {
        float minDistance = Mathf.Infinity;

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        EnemyAnimator.SetBool("Walk", false);
        EnemyAnimator.SetBool("Attack", false);

        if (distance < minDistance)
            minDistance = distance;

        if (minDistance < DistanceToFollow)
        {
            if (minDistance <= _distanceToAttack)
            {
                SetState(EnemyState.Attack);
            }
            else 
            {
                SetState(EnemyState.WalkToPlayer);
            }
        }
        else
            SetState(EnemyState.Idle);
    }

    public void MakeDamageToPlayer()
    {
        float minDistance = Mathf.Infinity;

        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < minDistance)
            minDistance = distance;

        if (minDistance < _distanceToAttack)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
