using UnityEngine;

public class UIReferences : MonoBehaviour
{
    public static UIReferences Instance;

    public GameObject checkListMin;
    public GameObject checkListMax;
    public bool minMax;
    public bool pickPaper;
    public GameObject bookRed;
    public GameObject bookGreen;
    public GameObject bookBlue;
    public GameObject bookYellow;

    public GameObject cabinets;
    public GameObject screenSettingsZerado;

    private PlayerManager playerManager; //  Fica null até ser setado

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Novo método para registrar o player
    public void SetPlayerManager(PlayerManager manager)
    {
        playerManager = manager;
    }

    // Só será chamado se playerManager tiver sido setado
    public void Show()
    {
        if (playerManager != null)
            playerManager.ToggleChecklist();
        else
            Debug.LogError("PlayerManager não foi setado no UIReferences!");
    }

}
