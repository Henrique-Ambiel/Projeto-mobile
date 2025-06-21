using UnityEngine;
using Terresquall;
using UnityEngine.SceneManagement;

// Gerencia o jogador, movimentação, interações e animações
public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 4f; // Velocidade do jogador
    private Rigidbody2D rb; // Componente de física
    public static bool isMove = true; // Flag que controla se o player pode se mover
    public GameObject Player; // Objeto visual do jogador
    private SpriteRenderer sp; // Componente de renderização do sprite

    [Header("Other Settings")]
    private PlayerTrigger playerTrigger; // Controle de gatilhos
    private MinCheckListSystem _minCheckListSystem; // Checklist mínima
    private MaxCheckListSytem _maxCheckListSytem; // Checklist máxima
    public GameObject minCheckList; // UI da checklist mínima
    public GameObject maxCheckList; // UI da checklist máxima
    public bool minMax; // Controle de qual checklist está ativa
    private ItemPickUp _itemPickUp; // Sistema de coleta (não usado no script)
    private GameObject cabinets; // Referência obtida da UIReferences
    static public int valueBook; // Valor compartilhado dos livros
    public GameObject paper; // Objeto que ativa checklist
    public int countSpawnBook = 0; // Controle para spawn único dos livros
    private Vector3 originalScale; // Escala original do jogador
    private GameObject screenSettingsZerado; // Tela de finalização
    public static bool cabinetsActive = false; // Controle de visibilidade dos armários


    public string characterPrefix = "Boy"; // Prefixo para animações (Boy ou Girl)

    public  Animator animator; // Componente de animação
      private bool escondido = false;

    private void Start()
    {
        UIReferences.Instance.SetPlayerManager(this);

        countSpawnBook = 0;

        sp = GetComponent<SpriteRenderer>(); // Inicializa SpriteRenderer
        rb = GetComponent<Rigidbody2D>(); // Inicializa Rigidbody
        isMove = true; // Ativa movimentação
        valueBook = 0; // Zera valor dos livros
        minMax = false; // Checklist começa inativa
        playerTrigger = new PlayerTrigger(this); // Inicializa sistema de gatilhos


        minCheckList = UIReferences.Instance.checkListMin; // Pega checklist mínima
        maxCheckList = UIReferences.Instance.checkListMax; // Pega checklist máxima
        cabinets = UIReferences.Instance.cabinets; // Pega armários

        screenSettingsZerado = UIReferences.Instance.screenSettingsZerado; // Pega tela de finalização

        _minCheckListSystem = new MinCheckListSystem(minCheckList); // Inicializa checklist mínima
        _maxCheckListSytem = new MaxCheckListSytem(maxCheckList); // Inicializa checklist máxima

        originalScale = transform.localScale; // Armazena escala inicial

        characterPrefix = PlayerUtils.GetCharacterPrefix(); // Define prefixo da skin selecionada
        Debug.Log(characterPrefix);

        animator = GetComponent<Animator>(); // Pega o Animator


    }

    public void ShowCabinets()
    {
        cabinets.SetActive(true);
        PlayerStop();  // Para movimento quando livros aparecem
        Debug.Log("Cabinets ativados");
    }

    public void HideCabinets()
    {
        cabinets.SetActive(false);
        PlayerUnStop();  // Retoma movimento quando livros somem
        Debug.Log("Cabinets desativados");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTrigger.TriggerEnter2D(other);

        

        if (other.CompareTag("paper"))
        {
            if (countSpawnBook == 0)
            {
                UIReferences.Instance.pickPaper = true;
                SpawnBook();
                countSpawnBook++;

                Debug.Log("paper trigger");

                if (maxCheckList != null)
                {
                    maxCheckList.SetActive(true);
                    PlayerStop(); // Impede movimento ao abrir checklist
                }
            }
        }


        if (other.CompareTag("nextPhase"))
        {
          SceneManager.LoadScene("IAScene"); // Carrega próxima fase
        }
    }


    private void FixedUpdate()
    {
        Move(); // Movimento contínuo no FixedUpdate
        Animation(); // Atualiza animação
    }

    public void SpawnBook()
    {
        UIReferences.Instance.bookRed.SetActive(true); // Ativa livro vermelho
        UIReferences.Instance.bookGreen.SetActive(true); // Ativa livro verde
        UIReferences.Instance.bookBlue.SetActive(true); // Ativa livro azul
        UIReferences.Instance.bookYellow.SetActive(true); // Ativa livro amarelo

    }


    public void PlayerStop()
    {
        isMove = false; // Para o movimento externamente
        animator.Play("idle"); // Para animação
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
        else if (!isMove)
        {
            
            rb.linearVelocity = Vector2.zero; // Para movimento
            moveSpeed = 0f; // Zera velocidade
        }
    }

    public void ToggleChecklist()
    {
        minMax = !minMax;
        UIReferences.Instance.minMax = minMax;

        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);

        if (minMax)
            PlayerUnStop(); // Checklist mínima ativa = pode andar
        else
            PlayerStop();   // Checklist máxima ativa = para o movimento
    }

    public void Animation()
    {
        if (!isMove) return;

        Vector2 velocity = rb.linearVelocity;
        float speed = velocity.magnitude;

        if (speed == 0f)
        {
            animator.Play("idle");
        }

        // Detecção de direção dominante
        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
        {
            // Movimento horizontal (esquerda ou direita)
            animator.Play("walk");

            if (velocity.x > 0f)
            {
                // Indo para a direita (sem flip)
                sp.flipX = false;
            }
            else
            {
                // Indo para a esquerda (com flip)
                sp.flipX = true;
            }
        }
        else
        {
            // Movimento vertical
            if (velocity.y > 0f)
            {
                animator.Play("walkUp");
            }
            if(velocity.y < 0f)
            {
                animator.Play("walkDown");
            }
        }
    }

    public void Hide()
    {
        escondido = true;

        PlayerStop();
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject.FindAnyObjectByType<EnemyAI>().seguindo = false; // faz a IA esquecer
        Debug.Log("Escondido");
    }

    public void Unhide()
    {
        escondido = false;

        PlayerUnStop();
        GetComponent<SpriteRenderer>().enabled = true;
        Debug.Log("Saiu do esconderijo");
    }

    public void ToggleHide()
    {
        if (escondido)
            Unhide();
        else
            Hide();
    }

    public bool IsHidden()
    {
        return escondido;
    }
}
