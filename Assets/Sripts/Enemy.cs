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

    public int Health;
    public GameObject Player;
    public float DistanceToFollow = 7f;
    public float DistanceToAttack = 1f;

    public NavMeshAgent NavMeshAgent;

    public Animator EnemyAnimator;

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        if (CurrentEnemyState == EnemyState.Idle)
        {

        }
        else if (CurrentEnemyState == EnemyState.WalkToPlayer)
        {
            NavMeshAgent.SetDestination(Player.transform.position);
        }
        else if (CurrentEnemyState == EnemyState.Attack)
        {

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

        if (distance < minDistance)
            minDistance = distance;

        if (minDistance < DistanceToFollow)
        {
            if (minDistance < DistanceToAttack)
            {
                SetState(EnemyState.Attack);
                EnemyAnimator.SetTrigger("Attack");
            }
            else
            {
                SetState(EnemyState.WalkToPlayer);
                EnemyAnimator.SetBool("Walk", true);
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

        if (minDistance < DistanceToAttack)
        {
            Player.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
