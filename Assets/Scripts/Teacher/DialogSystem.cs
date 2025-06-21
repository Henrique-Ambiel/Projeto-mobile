using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{

    [Header("Conteúdo do Diálogo")]
    public string[] dialogTexts;
    public Sprite[] dialogImages;

    [Header("Referências UI")]
    public GameObject dialogPanel; // Painel que contém o diálogo
    public Image illustrationImage;
    public TextMeshProUGUI dialogText;
    public Button nextButton;
    public Image buttonVisual; // Referência à imagem do botão (para mudar cor)

    [Header("Configurações")]
    public float typingSpeed = 0.05f;
    public float waitAfterTyping = 1.5f;

    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool canAdvance = false;
    private bool dialogStarted = false;
    private Animator animator; // Referência ao Animator do diálogo


    PlayerManager playerManager; // Referência ao PlayerManager

    void Start()
    {
        dialogStarted = false; // Inicializa o estado do diálogo como não iniciado
        animator = GetComponent<Animator>(); // Obtém o componente Animator do diálogo
        animator.Play("idle"); // Inicia a animação idle do diálogo
        playerManager = FindAnyObjectByType<PlayerManager>(); // Obtém referência ao PlayerManager
        nextButton.onClick.AddListener(OnNextClicked);
        nextButton.gameObject.SetActive(false);
        illustrationImage.gameObject.SetActive(false);
        dialogText.text = "";

        SetButtonColor(Color.red);
        dialogTexts[1] = "Que bom que você chegou <b><color=#00FF00> " + ScreenCharacter.namePlayer + "</color></b>! Mas… a sala está uma bagunça…";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!dialogStarted && other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true); // Ativa o painel de diálogo
            dialogStarted = true;
            PlayerManager.isMove = false; // Desativa movimento do jogador
            playerManager.animator.Play("idle"); // Para a animação do jogador
            StartDialog();
        }
    }

    void StartDialog()
    {
        currentLineIndex = 0;
        nextButton.gameObject.SetActive(true);
        illustrationImage.gameObject.SetActive(true);

        

        StartCoroutine(DisplayLine());
    }

    IEnumerator DisplayLine()
    {
        switch (currentLineIndex)
        {
            case 0:
                illustrationImage.color = new Color(1, 1, 1, 0);
                break;
            case 1:
                illustrationImage.color = new Color(1, 1, 1, 0);
                break;
            case 2:
                illustrationImage.color = new Color(1, 1, 1, 1);
                illustrationImage.sprite = dialogImages[0];
                break;
            case 3:
                illustrationImage.sprite = dialogImages[1];
                break;
            case 4:
                illustrationImage.sprite = dialogImages[2];
                break;
            case 5:
                illustrationImage.sprite = dialogImages[3];
                break;
            case 6:
                illustrationImage.sprite = dialogImages[4];
                break;
            case 7:
                illustrationImage.sprite = dialogImages[5];
                break;
            case 8:
                illustrationImage.sprite = dialogImages[6];
                break;
            case 9:
                illustrationImage.sprite = dialogImages[7];
                break;
            case 10:
                illustrationImage.sprite = dialogImages[8];
                break;
            case 11:
                illustrationImage.sprite = dialogImages[2];
                break;
                case 12:
                illustrationImage.color = new Color(1, 1, 1, 0);
                break;
        }
        dialogText.text = "";
        isTyping = true;
        canAdvance = false;
        SetButtonColor(Color.red);

        

        string line = dialogTexts[currentLineIndex];

        foreach (char c in line)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        // Espera X segundos depois que o texto acabar
        yield return new WaitForSeconds(waitAfterTyping);

        canAdvance = true;
        SetButtonColor(Color.green);
    }

    void OnNextClicked()
    {
        if (!canAdvance || isTyping)
            return;

        canAdvance = false;
        SetButtonColor(Color.red);

        currentLineIndex++;

        if (currentLineIndex < dialogTexts.Length)
        {
            StartCoroutine(DisplayLine());
        }
        else
        {
            EndDialog();
        }
    }

    void EndDialog()
    {
        dialogText.text = "";
        nextButton.gameObject.SetActive(false);
        illustrationImage.gameObject.SetActive(false);
        dialogPanel.SetActive(false); // Desativa a UI
        animator.Play("stop");
        PlayerManager.isMove = true; // Ativa movimento do jogador novamente
    }

    void SetButtonColor(Color color)
    {
        if (buttonVisual != null)
        {
            buttonVisual.color = color;
        }
    }
}
