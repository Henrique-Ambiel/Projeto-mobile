using System.Collections.Generic;
using UnityEngine;

public class StatePatrol : IState
{
    private StateMachine stateMachine;
    private EnemyAI enemy;
    private List<Vector3> patrolPoints;
    private GameObject player;

    private Vector3 currentTarget;
    private float reachThreshold = 0.2f;

    private bool waiting = false;
    private float waitTimer = 0f;
    private float waitDuration = 3f;

    private int lastTargetIndex = -1; // índice do último ponto patrulhado, inicializado com -1

    public StatePatrol(StateMachine sm, EnemyAI enemyAI, List<Vector3> points)
    {
        stateMachine = sm;
        enemy = enemyAI;
        patrolPoints = points;
    }

    public void Enter()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy.seguindo = false; // Desativa o bool seguindo
        PickNewTarget();
    }

    public void Update()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitDuration)
            {
                waiting = false;
                waitTimer = 0f;
                PickNewTarget();
            }
            return;
        }

        if (enemy.currentPath == null || enemy.currentPath.Count == 0)
        {
            waiting = true;
            return;
        }

        //  AQUI: só persegue se o jogador não estiver escondido
        if (player != null && !player.GetComponent<PlayerManager>().IsHidden())
        {
            if (Vector3.Distance(enemy.transform.position, player.transform.position) <= IAGameManager.distanceChaseIA)
            {
                stateMachine.ChangeState(new StateChase(stateMachine, enemy, player.transform));
                return;
            }
        }
    }



    public void Exit()
    {
        enemy.SetPath(null);
    }

    private void PickNewTarget()
    {
        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogWarning("PickNewTarget: Lista de pontos vazia ou nula.");
            return;
        }

        int newIndex = lastTargetIndex;

        // Enquanto o novo índice for igual ao anterior e houver mais de 1 ponto, tenta outro índice
        while (newIndex == lastTargetIndex && patrolPoints.Count > 1)
        {
            newIndex = Random.Range(0, patrolPoints.Count);
        }

        lastTargetIndex = newIndex;
        currentTarget = patrolPoints[newIndex];

        Debug.Log($"Novo destino de patrulha: {currentTarget} (índice {newIndex})");

        List<Node> path = enemy.pathfinder.FindPath(enemy.transform.position, currentTarget);
        enemy.SetPath(path);
    }
}
