using UnityEngine;
using Terresquall;
using JetBrains.Annotations;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 4f;
    private Rigidbody2D rb;
    public bool isMove = true;
    public GameObject Player;

    [Header("Other Settings")]
    private PlayerTrigger playerTrigger;
    private MinCheckListSystem _minCheckListSystem;
    private MaxCheckListSytem _maxCheckListSytem;
    public GameObject minCheckList;
    public GameObject maxCheckList;
    public bool minMax;
    private ItemPickUp _itemPickUp;
    public GameObject cabinets;
    public GameObject[] books;
    static public int valueBook;
    public GameObject paper;
    public int countSpawnBook = 0;
    public PlayerAnimationController playerAnimationController;
    private Vector3 originalScale;
    public GameObject screenSettingsZerado;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMove = true;
        valueBook = 0;
        minMax = false;
        playerTrigger = new PlayerTrigger(this);

        // Inicializa o CheckListSystem, passando a referência ao minCheckList
        _minCheckListSystem = new MinCheckListSystem(minCheckList);
        _maxCheckListSytem = new MaxCheckListSytem(maxCheckList);

        originalScale = transform.localScale; // Guarda a escala original
    }

    // Chama o TriggerEnter para o PlayerTrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTrigger.TriggerEnter2D(other);

        if (other.CompareTag("paper"))
        {
            if (countSpawnBook == 0)
            {
                Debug.Log("paper trigger");

                maxCheckList.SetActive(true);
                isMove = false;
                SpawnBook();
                countSpawnBook++;
            }
        }
        if (other.CompareTag("end"))
        {
            screenSettingsZerado.SetActive(true);
            isMove=false; 
          
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void SpawnBook()
    {
        for (int i = 0; i < books.Length; i++)
        {
            books[i].SetActive(true);
        }
    }

    public void PlayerStop()
    {
        isMove = false;
    }
    public void PlayerUnStop()
    {
        isMove = true;
    }

    public void Move()
    {
        if (isMove)
        {
            moveSpeed = 3f;
            Vector2 targetDirection = new Vector2(VirtualJoystick.GetAxis("Horizontal"), VirtualJoystick.GetAxis("Vertical"));

            // ----------- MOVIMENTO HORIZONTAL ----------//
            if (targetDirection.x != 0 || targetDirection.y != 0) // verificar se há movimento
            {
                if (Mathf.Abs(targetDirection.x) > Mathf.Abs(targetDirection.y)) // verifica se o movimento horizontal é mais forte, se for, move horizontalmente
                {
                    // movimento para a direita
                    if (targetDirection.x > 0)
                    {
                        playerAnimationController.PlayAnimation("PlayerXMovement"); // tocar animação de andar pra direita
                        Player.GetComponent<SpriteRenderer>().flipX = false; // desativar flip
                    }
                    // movimento para a esquerda
                    else if (targetDirection.x < 0)
                    {
                        playerAnimationController.PlayAnimation("PlayerXMovement"); // tocar animação de andar à esquerda
                        Player.GetComponent<SpriteRenderer>().flipX = true; // ativar flip
                    }
                }
                // ----------- MOVIMENTO VERTICAL ----------//
                else if (Mathf.Abs(targetDirection.y) > Mathf.Abs(targetDirection.x)) // Verifica se o movimento vertical é mais forte, se for, move verticallmente
                {
                    // movimento para cima
                    if (targetDirection.y > 0)
                    {
                        playerAnimationController.PlayAnimation("PlayerYMovement"); // tocar animação de andar para cima
                    }
                    // movimento para baixo
                    else if (targetDirection.y < 0)
                    {
                        playerAnimationController.PlayAnimation("PlayerYMovementDown"); // tocar animação de andar para baixo
                    }
                }
            }

            // ----------- IDLE -----------//
            if (targetDirection.x == 0 && targetDirection.y == 0)
            {
                playerAnimationController.PlayAnimation("PlayerIdle"); // se não há movimento, tocar animação idle
            }

            // Aqui está a movimentação do Rigidbody2D
            if (targetDirection.sqrMagnitude != 0) // Garante que só se move se houver input suficiente
            {
                targetDirection.Normalize(); // Normaliza para evitar velocidades diferentes em diagonais
                                             // Movimento direto, sem suavização excessiva
                rb.linearVelocity = targetDirection * moveSpeed; // Atualiza a velocidade diretamente
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // para o player quando não há input
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // se isMove for falso, para o player
            moveSpeed = 0f; // garantir que vá parar
            playerAnimationController.PlayAnimation("PlayerIdle");
        }
    }

    public void Show()
    {
        minMax = !minMax;
        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);

        isMove = minMax;
    }
}
