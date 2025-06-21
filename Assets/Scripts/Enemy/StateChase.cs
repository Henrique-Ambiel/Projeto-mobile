using System.Collections.Generic;
using UnityEngine;

public class StateChase : IState
{
    private StateMachine stateMachine;

    private EnemyAI enemy;
    private Transform player;

    private float updatePathTimer = 0f;
    private float updatePathInterval = 0.5f;

    public StateChase(StateMachine sm, EnemyAI enemyAI, Transform playerTransform)
    {
        stateMachine = sm;
        enemy = enemyAI;
        player = playerTransform;
    }

    public void Enter()
    {
        enemy.seguindo = true; // Ativa o bool seguindo
        RequestPathToPlayer();
        Debug.Log("Iniciando perseguição ao jogador: ");
    }

    public void Update()
    {
        updatePathTimer += Time.deltaTime;

        if (updatePathTimer >= updatePathInterval)
        {
            updatePathTimer = 0f;
            RequestPathToPlayer();
        }

        PlayerManager pm = player.GetComponent<PlayerManager>();

        // Se jogador estiver escondido ou longe ou "seguindo" desligado
        if (pm != null && (pm.IsHidden() || Vector3.Distance(enemy.transform.position, player.position) > IAGameManager.distanceIA || !enemy.seguindo))
        {
            Debug.Log("Jogador perdido, escondido ou bool desligada, voltando pra patrulha.");
            stateMachine.ChangeState(new StatePatrol(stateMachine, enemy, enemy.GetPatrolPoints()));
            return;
        }
    }



    public void Exit()
    {
        enemy.seguindo = false; // Desativa o bool seguindo
        enemy.SetPath(null);
    }

    private void RequestPathToPlayer()
    {
        List<Node> path = enemy.pathfinder.FindPath(enemy.transform.position, player.position);
        enemy.SetPath(path);
    }
}
