using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerTrigger playerTrigger;
    private MinCheckListSystem _minCheckListSystem;
    private MaxCheckListSytem _maxCheckListSytem;
    public GameObject minCheckList; 
    public GameObject maxCheckList;
    public bool minMax;

    private void Start()
    {
        minMax = true;
        playerTrigger = new PlayerTrigger(this);

        // Inicializa o CheckListSystem, passando a referência ao minCheckList
        _minCheckListSystem = new MinCheckListSystem(minCheckList);
        _maxCheckListSytem= new MaxCheckListSytem(maxCheckList);


    }

    // Chama o TriggerEnter para o PlayerTrigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerTrigger.TriggerEnter2D(other);


    }

    public void Show()
    {
        minMax = !minMax;
        minCheckList.SetActive(minMax);
        maxCheckList.SetActive(!minMax);
    }
}
