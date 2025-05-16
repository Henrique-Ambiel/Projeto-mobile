using UnityEngine;
using Terresquall;

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
    private Vector3 originalScale;
    public GameObject screenSettingsZerado;

    public string characterPrefix = "Boy"; // Defina no prefab: "Boy" ou "Girl"
    public PlayerAnimationController playerAnimationController;

    private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMove = true;
        valueBook = 0;
        minMax = false;
        playerTrigger = new PlayerTrigger(this);

        _minCheckListSystem = new MinCheckListSystem(minCheckList);
        _maxCheckListSytem = new MaxCheckListSytem(maxCheckList);

        originalScale = transform.localScale;

        // Lê skin selecionada para definir o prefixo correto (Boy ou Girl)
        characterPrefix = PlayerUtils.GetCharacterPrefix();

        // Inicializa a animação com o Animator do próprio Player
        animator = GetComponent<Animator>();
        playerAnimationController.Init(animator, characterPrefix);
    }


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
            isMove = false;
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

            if (targetDirection != Vector2.zero)
            {
                if (targetDirection.x > 0) Player.GetComponent<SpriteRenderer>().flipX = false;
                if (targetDirection.x < 0) Player.GetComponent<SpriteRenderer>().flipX = true;

                playerAnimationController.SetMovement(targetDirection.x, targetDirection.y);
            }
            else
            {
                playerAnimationController.SetMovement(0, 0);
            }

            if (targetDirection.sqrMagnitude != 0)
            {
                targetDirection.Normalize();
                rb.linearVelocity = targetDirection * moveSpeed;
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            moveSpeed = 0f;
            playerAnimationController.SetMovement(0, 0); // Idle forçado
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
