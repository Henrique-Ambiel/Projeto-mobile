using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem1 : MonoBehaviour
{

    [Header("Conte�do do Di�logo")]
    public string[] dialogTexts;
    public Sprite[] dialogImages;

    [Header("Refer�ncias UI")]
    public GameObject dialogPanel; // Painel que cont�m o di�logo
    public Image illustrationImage;
    public TextMeshProUGUI dialogText;
    public Button nextButton;
    public Image buttonVisual; // Refer�ncia � imagem do bot�o (para mudar cor)

    [Header("Configura��es")]
    public float typingSpeed = 0.05f;
    public float waitAfterTyping = 1.5f;
    public Button skipButton; // Bot�o para pular o di�logo


    private int currentLineIndex = 0;
    private bool isTyping = false;
    private bool canAdvance = false;
    private bool dialogStarted = false;
    private Animator animator; // Refer�ncia ao Animator do di�logo


    PlayerManager playerManager; // Refer�ncia ao PlayerManager

    void Start()
    {
        
        animator = GetComponent<Animator>(); // Obt�m o componente Animator do di�logo
        animator.Play("idle"); // Inicia a anima��o idle do di�logo
        playerManager = FindAnyObjectByType<PlayerManager>(); // Obt�m refer�ncia ao PlayerManager
        nextButton.onClick.AddListener(OnNextClicked);
        skipButton.onClick.AddListener(SkipDialog);
        skipButton.gameObject.SetActive(false);

        nextButton.gameObject.SetActive(false);
        illustrationImage.gameObject.SetActive(false);
        dialogText.text = "";

        SetButtonColor(Color.red);
        dialogTexts[0] = "Caramba,<b><color=#00FF00> " + ScreenCharacter.namePlayer + "</color></b>!!! A gente caiu no por�o.";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!dialogStarted && other.CompareTag("Player"))
        {
            Debug.Log("dialogo onn");
            dialogPanel.SetActive(true); // Ativa o painel de di�logo
            dialogStarted = true;
            PlayerManager.isMove = false; // Desativa movimento do jogador
            playerManager.animator.Play("idle"); // Para a anima��o do jogador
            StartDialog();
        }
    }

    void StartDialog()
    {
        currentLineIndex = 0;
        nextButton.gameObject.SetActive(true);
        skipButton.gameObject.SetActive(true); //  ativa aqui
        illustrationImage.gameObject.SetActive(true);
        StartCoroutine(DisplayLine());
    }

    void SkipDialog()
    {
        StopAllCoroutines(); // Para a digita��o

        EndDialog(); // Finaliza o di�logo imediatamente
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
