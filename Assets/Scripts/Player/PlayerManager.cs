using UnityEngine;
using Terresquall;
public class PlayerManager : MonoBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 5f;
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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        isMove = true;
        valueBook = 0;
        minMax = true;
        playerTrigger = new PlayerTrigger(this);

        // Inicializa o CheckListSystem, passando a refer�ncia ao minCheckList
        _minCheckListSystem = new MinCheckListSystem(minCheckList);
        _maxCheckListSytem= new MaxCheckListSytem(maxCheckList);
    }

    // Chama o TriggerEnter para o PlayerTrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTrigger.TriggerEnter2D(other);

        if (other.CompareTag("paper"))
        {
            for (int i = 0; i < books.Length; i++)
            {
                books[i].SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            Move();
        }
    }

    private void Update()
    {

    }

    public void Move()
    {
        Vector2 targetDirection = new Vector2(VirtualJoystick.GetAxis("Horizontal"), VirtualJoystick.GetAxis("Vertical"));

        
        if (targetDirection.sqrMagnitude > 0.01f)
        {
            
            targetDirection.Normalize();

            
            Vector2 smoothedVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetDirection * moveSpeed, ref currentVelocity, smoothTime);

            
            rb.linearVelocity = smoothedVelocity;
        }
        else
        {
            
            rb.linearVelocity = Vector2.zero;
        }
    }
    public void PlayerStop()
    {
        
    }

    public void Show()
    {
        minMax = !minMax;
        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);
    }
}
