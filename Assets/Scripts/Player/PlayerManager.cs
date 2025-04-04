using UnityEngine;
using Terresquall;

public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 4f;
    public float smoothTime = 0.1f;
    private Vector2 currentVelocity;
    private Rigidbody2D rb;
    public bool isMove = true;

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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMove = true;
        valueBook = 0;
        minMax = true;
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
            Debug.Log("paper trigger");

            minCheckList.SetActive(true);

            if (countSpawnBook == 0)
            {
                SpawnBook();
                countSpawnBook++;
            }
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

    public void Move()
    {
        if (isMove)
        {
            moveSpeed = 4f;
            Vector2 targetDirection = new Vector2(VirtualJoystick.GetAxis("Horizontal"), VirtualJoystick.GetAxis("Vertical"));

            float deadZone = 0.1f; // Define a zona morta para evitar animações oscilando

            if (Mathf.Abs(targetDirection.x) > Mathf.Abs(targetDirection.y) && Mathf.Abs(targetDirection.x) > deadZone)
            {
                // Movimento horizontal
                playerAnimationController.PlayAnimation("PlayerXMovement");

                // Flipa a sprite dependendo da direção
                if (- targetDirection.x < -deadZone)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
                }
                else if (-targetDirection.x > deadZone)
                {
                    transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
                }
            }
            else if (Mathf.Abs(targetDirection.y) > deadZone)
            {
                // Movimento vertical
                if (targetDirection.y > 0)
                    playerAnimationController.PlayAnimation("PlayerYMovement");
                else
                    playerAnimationController.PlayAnimation("PlayerYMovementDown");
            }

            // Aqui está a movimentação do Rigidbody2D
            if (targetDirection.sqrMagnitude > deadZone * deadZone) // Garante que só se move se houver input suficiente
            {
                targetDirection.Normalize(); // Normaliza para evitar velocidades diferentes em diagonais
                Vector2 smoothedVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetDirection * moveSpeed, ref currentVelocity, smoothTime);
                rb.linearVelocity = smoothedVelocity;
            }
            else
            {
                rb.linearVelocity = Vector2.zero; // Para quando não há input do joystick
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Se isMove for falso, para o player
            moveSpeed = 0f;
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
