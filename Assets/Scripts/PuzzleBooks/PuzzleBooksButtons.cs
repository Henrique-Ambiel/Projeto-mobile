using UnityEngine;

// Script respons�vel pelos bot�es do puzzle de livros
public class PuzzleBooksButtons : MonoBehaviour
{
    // Vari�veis de controle de resposta
    public string answer = ""; // Resposta do jogador
    public string correct = ""; // Resposta correta

    // Refer�ncias visuais
    public Sprite btOn; // Sprite que indica bot�o pressionado/correto
    public GameObject[] bts; // Lista dos bot�es que representam o progresso
    public GameObject[] books; // Livros que aparecem quando erra
    public GameObject backgroundCabinets; // Painel dos arm�rios
    public Animator animDoor; // Anima��o da porta
    public GameObject colDoor; // Colisor da porta, desativado quando aberta

    // Controle do progresso
    public int i = -1; // �ndice dos bot�es pressionados corretamente
    public bool[] booksCorrects; // Controle dos livros acertados

    // Refer�ncias aos objetos de letras e Libras
    public GameObject[] obj_Letras;
    public GameObject[] obj_LibrasLetra;
    public GameObject[] certos; // Itens que aparecem quando acerta

    // Refer�ncia ao PlayerManager
    private PlayerManager playerManager;

    // M�todo para definir manualmente o PlayerManager
    public void SetPlayerManager(PlayerManager pm)
    {
        playerManager = pm;
    }

    // Inicializa��o do script
    private void Start()
    {
        // Verifica se h� PlayerManager atribu�do, se n�o, busca na cena
        if (playerManager == null)
        {
            playerManager = FindAnyObjectByType<PlayerManager>();
            if (playerManager == null)
                Debug.LogError("PlayerManager n�o foi encontrado!");
        }
        i = -1;
    }

    // M�todo do bot�o da letra C
    public void BtC()
    {
        answer = "C";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3) // Abre a porta se acertou os 4
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra C em Libras
    public void BtC_libras()
    {
        Debug.Log("Clique no bot�o C Libras");
        answer = "C_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            // Esconde os objetos relacionados
            obj_Letras[0].SetActive(false);
            obj_LibrasLetra[2].SetActive(false);

            // Ativa os indicadores de acerto
            certos[1].SetActive(true);
            certos[4].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[0] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra F em Libras
    public void BtF_libras()
    {
        answer = "F_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_LibrasLetra[0].SetActive(false);
            obj_LibrasLetra[1].SetActive(false);

            certos[0].SetActive(true);
            certos[2].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[3] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra G
    public void BtG()
    {
        answer = "G";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_Letras[1].SetActive(false);
            obj_LibrasLetra[3].SetActive(false);

            certos[3].SetActive(true);
            certos[5].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[2] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra G em Libras
    public void BtG_libras()
    {
        answer = "G_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra T em Libras
    public void BtT_libras()
    {
        answer = "T_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra V
    public void BtV()
    {
        answer = "V";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    // M�todo do bot�o da letra Y
    public void BtY()
    {
        answer = "Y";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_Letras[2].SetActive(false);
            obj_Letras[3].SetActive(false);

            certos[6].SetActive(true);
            certos[7].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;

            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[1] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ProcessIncorrectAnswer();
        }
    }

    /// Executa as a��es quando a resposta est� incorreta.
    /// Mostra o livro correspondente � resposta correta.
    private void ProcessIncorrectAnswer()
    {
        ItemPickUp.CanAnswerPuzzle = false;
        PlayerManager.cabinetsActive = false;

        switch (correct)
        {
            case "C_Libras":
                books[0].SetActive(true);
                break;
            case "Y":
                books[1].SetActive(true);
                break;
            case "G":
                books[2].SetActive(true);
                break;
            case "F_Libras":
                books[3].SetActive(true);
                break;
        }

        correct = ""; // Reseta a resposta correta
    }
}
