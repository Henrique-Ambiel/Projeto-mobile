using UnityEngine;

// Script responsável pelos botões do puzzle de livros
public class PuzzleBooksButtons : MonoBehaviour
{
    // Variáveis de controle de resposta
    public string answer = ""; // Resposta do jogador
    public string correct = ""; // Resposta correta

    // Referências visuais
    public Sprite btOn; // Sprite que indica botão pressionado/correto
    public GameObject[] bts; // Lista dos botões que representam o progresso
    public GameObject[] books; // Livros que aparecem quando erra
    public GameObject backgroundCabinets; // Painel dos armários
    public Animator animDoor; // Animação da porta
    public GameObject colDoor; // Colisor da porta, desativado quando aberta

    // Controle do progresso
    public int i = -1; // Índice dos botões pressionados corretamente
    public bool[] booksCorrects; // Controle dos livros acertados

    // Referências aos objetos de letras e Libras
    public GameObject[] obj_Letras;
    public GameObject[] obj_LibrasLetra;
    public GameObject[] certos; // Itens que aparecem quando acerta

    // Referência ao PlayerManager
    private PlayerManager playerManager;

    // Método para definir manualmente o PlayerManager
    public void SetPlayerManager(PlayerManager pm)
    {
        playerManager = pm;
    }

    // Inicialização do script
    private void Start()
    {
        // Verifica se há PlayerManager atribuído, se não, busca na cena
        if (playerManager == null)
        {
            playerManager = FindAnyObjectByType<PlayerManager>();
            if (playerManager == null)
                Debug.LogError("PlayerManager não foi encontrado!");
        }
        i = -1;
    }

    // Método do botão da letra C
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

    // Método do botão da letra C em Libras
    public void BtC_libras()
    {
        Debug.Log("Clique no botão C Libras");
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

    // Método do botão da letra F em Libras
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

    // Método do botão da letra G
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

    // Método do botão da letra G em Libras
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

    // Método do botão da letra T em Libras
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

    // Método do botão da letra V
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

    // Método do botão da letra Y
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

    /// Executa as ações quando a resposta está incorreta.
    /// Mostra o livro correspondente à resposta correta.
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
