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
<<<<<<< Updated upstream
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
=======
    private PlayerTrigger playerTrigger; // Controle de gatilhos
    private MinCheckListSystem _minCheckListSystem; // Checklist mínima
    private MaxCheckListSytem _maxCheckListSytem; // Checklist máxima
    private GameObject minCheckList; // UI da checklist mínima
    private GameObject maxCheckList; // UI da checklist máxima
    public bool minMax; // Controle de qual checklist está ativa
    private ItemPickUp _itemPickUp; // Sistema de coleta (não usado no script)
    private GameObject cabinets; // Armários (não usado diretamente aqui)
    public GameObject[] books; // Array de livros que serão ativados
    static public int valueBook; // Valor compartilhado dos livros
    public GameObject paper; // Objeto que ativa checklist
    public int countSpawnBook = 0; // Controle para spawn único dos livros
    private Vector3 originalScale; // Escala original do jogador
    private GameObject screenSettingsZerado; // Tela de finalização

    private Animator animator; // Componente de animação
    private SpriteRenderer sr; // Componente de renderização de sprite

    private void Start()
    {
        animator = GetComponent<Animator>(); // Inicializa Animator
        rb = GetComponent<Rigidbody2D>(); // Inicializa Rigidbody
        isMove = true; // Ativa movimentação
        valueBook = 0; // Zera valor dos livros
        minMax = false; // Checklist começa inativa
        playerTrigger = new PlayerTrigger(this); // Inicializa sistema de gatilhos
>>>>>>> Stashed changes

        isMove = true;
        valueBook = 0;
        minMax = false;
        playerTrigger = new PlayerTrigger(this);

        // Inicializa o CheckListSystem, passando a referência ao minCheckList
        _minCheckListSystem = new MinCheckListSystem(minCheckList);
        _maxCheckListSytem = new MaxCheckListSytem(maxCheckList);

<<<<<<< Updated upstream
        originalScale = transform.localScale; // Guarda a escala original
=======
        sr = GetComponent<SpriteRenderer>(); // Inicializa SpriteRenderer
    }

    public void ShowCabinets(bool active)
    {
        cabinets.SetActive(active);
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
        Move();
=======
        Move(); // Movimento contínuo no FixedUpdate
        Animation(); // Atualiza animação
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
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
=======
                //playerAnimationController[].SetMovement(targetDirection.x, targetDirection.y); // Atualiza animação
            }
            else
            {
                //playerAnimationController.SetMovement(0, 0); // Animação de idle
            }

            if (targetDirection.sqrMagnitude != 0)
            {
                targetDirection.Normalize(); // Normaliza direção
                rb.linearVelocity = targetDirection * moveSpeed; // Aplica movimento
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // Para se não estiver se movendo
>>>>>>> Stashed changes
            }
        }
        else
        {
<<<<<<< Updated upstream
            rb.linearVelocity = Vector2.zero; // se isMove for falso, para o player
            moveSpeed = 0f; // garantir que vá parar
            playerAnimationController.PlayAnimation("PlayerIdle");
=======
            rb.linearVelocity = Vector2.zero; // Para movimento
            moveSpeed = 0f; // Zera velocidade
            //playerAnimationController.SetMovement(0, 0); // Força idle
>>>>>>> Stashed changes
        }
    }

    public void Show()
    {
        minMax = !minMax;
        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);

        isMove = minMax;
    }

    private string currentAnimation = "";

    private void PlayIfNotPlaying(string animationName) // verifica se a animação atual é diferente da nova
    {
    if (currentAnimation == animationName) return; // se a animação atual for a mesma, não faz nada

        animator.Play(animationName); // toca a nova animação
        currentAnimation = animationName; // atualiza animação atual
    }
    public void Animation() // atualiza animação com base na velocidade
    {
        if (!isMove) return; // para de atualizar animação se não estiver se movendo

        Vector2 velocity = rb.linearVelocity; // pega velocidade atual
        float speed = velocity.magnitude; // calcula magnitude da velocidade

        if (speed == 0f) // se a velocidade for zero
        {
            PlayIfNotPlaying("idle"); // toca animação idle
            return; // sai do método
        }
        
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y)) // se o movimento for horizontal
        {
            // Horizontal
            PlayIfNotPlaying("walk");

            
            if (velocity.x < 0) 
                sr.flipX = true; // vira sprite para esquerda
            else
                sr.flipX = false; // senão, vira sprite para direita
        }
        else // se o movimento for vertical
        {
            
            if (velocity.y > 0) // se o movimento for para cima
                PlayIfNotPlaying("walkUp");
            else
                PlayIfNotPlaying("walkDown"); // senão, o movimento é para baixo
        }
    }
}
