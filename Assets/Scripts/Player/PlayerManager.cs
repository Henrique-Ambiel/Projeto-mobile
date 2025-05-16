using UnityEngine;
using Terresquall;

// Gerencia o jogador, movimentação, interações e animações
public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 4f; // Velocidade do jogador
    private Rigidbody2D rb; // Componente de física
    public bool isMove = true; // Flag que controla se o player pode se mover
    public GameObject Player; // Objeto visual do jogador

    [Header("Other Settings")]
    private PlayerTrigger playerTrigger; // Controle de gatilhos
    private MinCheckListSystem _minCheckListSystem; // Checklist mínima
    private MaxCheckListSytem _maxCheckListSytem; // Checklist máxima
    public GameObject minCheckList; // UI da checklist mínima
    public GameObject maxCheckList; // UI da checklist máxima
    public bool minMax; // Controle de qual checklist está ativa
    private ItemPickUp _itemPickUp; // Sistema de coleta (não usado no script)
    public GameObject cabinets; // Armários (não usado diretamente aqui)
    public GameObject[] books; // Array de livros que serão ativados
    static public int valueBook; // Valor compartilhado dos livros
    public GameObject paper; // Objeto que ativa checklist
    public int countSpawnBook = 0; // Controle para spawn único dos livros
    private Vector3 originalScale; // Escala original do jogador
    public GameObject screenSettingsZerado; // Tela de finalização

    public string characterPrefix = "Boy"; // Prefixo para animações (Boy ou Girl)
    public PlayerAnimationController playerAnimationController; // Controlador de animações

    private Animator animator; // Componente de animação

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Inicializa Rigidbody
        isMove = true; // Ativa movimentação
        valueBook = 0; // Zera valor dos livros
        minMax = false; // Checklist começa inativa
        playerTrigger = new PlayerTrigger(this); // Inicializa sistema de gatilhos

        _minCheckListSystem = new MinCheckListSystem(minCheckList); // Inicializa checklist mínima
        _maxCheckListSytem = new MaxCheckListSytem(maxCheckList); // Inicializa checklist máxima

        originalScale = transform.localScale; // Armazena escala inicial

        characterPrefix = PlayerUtils.GetCharacterPrefix(); // Define prefixo da skin selecionada

        animator = GetComponent<Animator>(); // Pega o Animator
        playerAnimationController.Init(animator, characterPrefix); // Inicializa o controlador de animação
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTrigger.TriggerEnter2D(other); // Encaminha evento ao sistema de gatilho

        if (other.CompareTag("paper")) // Ao colidir com o papel
        {
            if (countSpawnBook == 0)
            {
                Debug.Log("paper trigger");

                maxCheckList.SetActive(true); // Ativa checklist máxima
                isMove = false; // Para movimento
                SpawnBook(); // Mostra livros
                countSpawnBook++; // Garante que só aconteça uma vez
            }
        }

        if (other.CompareTag("end")) // Ao colidir com a saída
        {
            screenSettingsZerado.SetActive(true); // Mostra tela final
            isMove = false; // Para movimento
        }
    }

    private void FixedUpdate()
    {
        Move(); // Movimento contínuo no FixedUpdate
    }

    public void SpawnBook()
    {
        for (int i = 0; i < books.Length; i++) books[i].SetActive(true); // Ativa todos os livros
    }

    public void PlayerStop()
    {
        isMove = false; // Para o movimento externamente
    }

    public void PlayerUnStop()
    {
        isMove = true; // Reativa o movimento
    }

    public void Move()
    {
        if (isMove)
        {
            moveSpeed = 3f; // Define velocidade padrão

            Vector2 targetDirection = new Vector2(VirtualJoystick.GetAxis("Horizontal"), VirtualJoystick.GetAxis("Vertical")); // Lê direção do joystick

            if (targetDirection != Vector2.zero)
            {
                if (targetDirection.x > 0) Player.GetComponent<SpriteRenderer>().flipX = false; // Vira sprite para direita
                if (targetDirection.x < 0) Player.GetComponent<SpriteRenderer>().flipX = true; // Vira sprite para esquerda

                playerAnimationController.SetMovement(targetDirection.x, targetDirection.y); // Atualiza animação
            }
            else
            {
                playerAnimationController.SetMovement(0, 0); // Animação de idle
            }

            if (targetDirection.sqrMagnitude != 0)
            {
                targetDirection.Normalize(); // Normaliza direção
                rb.linearVelocity = targetDirection * moveSpeed; // Aplica movimento
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // Para se não estiver se movendo
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Para movimento
            moveSpeed = 0f; // Zera velocidade
            playerAnimationController.SetMovement(0, 0); // Força idle
        }
    }

    public void Show()
    {
        minMax = !minMax; // Alterna entre os modos

        minCheckList.SetActive(minMax); // Ativa checklist mínima se minMax = true
        maxCheckList.SetActive(!minMax); // Ativa checklist máxima se minMax = false

        isMove = minMax; // Ativa movimento apenas se for checklist mínima
    }
}
