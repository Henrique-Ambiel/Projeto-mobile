using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Referências")]
    public Pathfinder pathfinder;
    public PatrolRoute patrolRoute;
    public GameObject player;

    [Header("Movimento")]
    
    private Animator animator;
    private Vector3 lastMoveDirection;


    [Header("Controle de perseguição")]
    public bool seguindo = false;

    // FSM e controle de estado
    private StateMachine stateMachine;
    private List<Vector3> patrolPoints;


    // Caminho atual
    public List<Node> currentPath;
    private int targetNodeIndex;
    private Vector3 currentTargetPosition;


    public GameObject DeadScreen;
    public Color colorSeguindo;

    public List<Vector3> GetPatrolPoints()
    {
        return patrolPoints;
    }
    private void Awake()
    {
        stateMachine = new StateMachine(this);
        player = GameObject.FindGameObjectWithTag("Player");

        if (patrolRoute == null)
        {
            Debug.LogError("EnemyAI: patrolRoute NÃO foi atribuído.");
            return;
        }

        patrolPoints = patrolRoute.GetPatrolPointsForLevel(IAGameManager.IA_Lvl);


        if (patrolPoints == null || patrolPoints.Count == 0)
        {
            Debug.LogError("EnemyAI: Nenhum ponto de patrulha para IA_Lvl: " + IAGameManager.IA_Lvl);
            return;
        }

        stateMachine.ChangeState(new StatePatrol(stateMachine, this, patrolPoints));

        animator = GetComponent<Animator>();
    }

    private int lastKnownLevel = -1; // Adicione esta linha fora de qualquer método

    private void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            Debug.DrawLine(transform.position, player.transform.position, distance < IAGameManager.distanceChaseIA ? Color.green : Color.gray);
        }

        if (seguindo) GetComponent<SpriteRenderer>().color = colorSeguindo;
        else GetComponent<SpriteRenderer>().color = Color.white;
        stateMachine.Update();
        MoveAlongPath();

        if (lastKnownLevel != IAGameManager.IA_Lvl)
        {
            lastKnownLevel = IAGameManager.IA_Lvl;
            patrolPoints = patrolRoute.GetPatrolPointsForLevel(lastKnownLevel);
            Debug.Log("EnemyAI atualizou patrolPoints com novo nível: " + lastKnownLevel);

            // Se estiver patrulhando, reinicia o estado com os novos pontos
            if (stateMachine.CurrentState is StatePatrol)
            {
                stateMachine.ChangeState(new StatePatrol(stateMachine, this, patrolPoints));
            }
        }
    }



    public void SetPath(List<Node> path)
    {
        currentPath = path;
        targetNodeIndex = 0;

        if (currentPath != null && currentPath.Count > 0)
        {
            currentTargetPosition = GridManager.Instance.groundTilemap
                .CellToWorld((Vector3Int)currentPath[0].gridPosition) + new Vector3(0.5f, 0.5f, 0);
        }
    }

    public void MoveAlongPath()
    {
        if (currentPath == null || currentPath.Count == 0)
            return;

        Vector3 pos = transform.position;
        Vector3 direction = (currentTargetPosition - pos).normalized;

        transform.position += direction *IAGameManager.moveSpeedIA * Time.deltaTime;

        // Atualiza animação baseada na direção do movimento
        UpdateAnimation(direction);

        if (Vector3.Distance(transform.position, currentTargetPosition) < 0.1f)
        {
            targetNodeIndex++;
            if (targetNodeIndex >= currentPath.Count)
            {
                currentPath = null;
                animator.Play("Idle"); // Para quando termina o caminho
            }
            else
            {
                currentTargetPosition = GridManager.Instance.groundTilemap
                    .CellToWorld((Vector3Int)currentPath[targetNodeIndex].gridPosition) + new Vector3(0.5f, 0.5f, 0);
            }
        }
    }


    private string currentAnimation = "";

    private void UpdateAnimation(Vector3 direction)
    {
        string newAnimation = "";

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            newAnimation = direction.x > 0 ? "walkRight" : "walkLeft";
        }
        else
        {
            newAnimation = direction.y > 0 ? "walkUp" : "walkDown";
        }

        if (newAnimation != currentAnimation)
        {
            currentAnimation = newAnimation;
            animator.Play(currentAnimation);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager playerManager = collision.GetComponent<PlayerManager>();

            if (playerManager != null && playerManager.IsHidden())
            {
                // Jogador está escondido, ignore
                return;
            }

            // Jogador não está escondido, pode matar
            DeadScreen.SetActive(true);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
