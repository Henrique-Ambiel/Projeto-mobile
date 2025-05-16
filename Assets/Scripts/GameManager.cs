using UnityEngine;

// Classe responsável por gerenciar o início do jogo e instanciar o personagem escolhido
public class GameManager : MonoBehaviour
{
    // Referência ao prefab do menino e da menina
    public GameObject prefabBoy;
    public GameObject prefabGirl;

    // Referência para guardar a instância atual do personagem criado na cena
    private GameObject playerInstance;

    // Método chamado automaticamente quando o jogo inicia
    void Start()
    {
        string skin = UserData.GetSkin(); // Recupera a skin selecionada pelo jogador, salva anteriormente

        // Verifica qual skin foi selecionada
        if (skin == "Menino")
        {   
            playerInstance = Instantiate(prefabBoy, Vector3.zero, Quaternion.identity); // Instancia o prefab do menino na posição (0,0,0) com rotação padrão
        }
        else
        {
            playerInstance = Instantiate(prefabGirl, Vector3.zero, Quaternion.identity); // Instancia o prefab da menina na posição (0,0,0) com rotação padrão
        }
    }
}

