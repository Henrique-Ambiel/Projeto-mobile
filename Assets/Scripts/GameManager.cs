using UnityEngine;

// Classe respons�vel por gerenciar o in�cio do jogo e instanciar o personagem escolhido
public class GameManager : MonoBehaviour
{
    // Refer�ncia ao prefab do menino e da menina
    public GameObject prefabBoy;
    public GameObject prefabGirl;

    // Refer�ncia para guardar a inst�ncia atual do personagem criado na cena
    private GameObject playerInstance;

    // M�todo chamado automaticamente quando o jogo inicia
    void Start()
    {
        string skin = UserData.GetSkin(); // Recupera a skin selecionada pelo jogador, salva anteriormente

        // Verifica qual skin foi selecionada
        if (skin == "Menino")
        {   
            playerInstance = Instantiate(prefabBoy, Vector3.zero, Quaternion.identity); // Instancia o prefab do menino na posi��o (0,0,0) com rota��o padr�o
        }
        else
        {
            playerInstance = Instantiate(prefabGirl, Vector3.zero, Quaternion.identity); // Instancia o prefab da menina na posi��o (0,0,0) com rota��o padr�o
        }
    }
}

