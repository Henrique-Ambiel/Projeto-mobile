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

    private void Update()
    {

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
            moveSpeed = 4;
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
        else
        {
            rb.linearVelocity = Vector2.zero;
            moveSpeed = 0;
        }
    }

    public void Show()
    {
        minMax = !minMax;
        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);

        if (!minMax)
        {
            isMove = false;
        }
        if (minMax)
        {
            isMove = true;
        }
    }
}
