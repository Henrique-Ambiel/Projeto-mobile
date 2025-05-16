using UnityEngine;

// Esta classe é responsável por instanciar o personagem selecionado pelo jogador no início da cena
public class PlayerSpawn : MonoBehaviour
{
    // Prefab do menino e da menina
    public GameObject playerBoyPrefab;
    public GameObject playerGirlPrefab;

    // Método chamado automaticamente quando o jogo inicia
    void Start()
    {
        string skinSelected = PlayerPrefs.GetString("skinSelecionada", "Menino");  // Recupera a skin selecionada salva no PlayerPrefs (padrão: "Menino" caso não exista)

        // Escolhe o prefab correspondente com base na skin selecionada usando operador ternário
        GameObject playerPrefabToSpawn = (skinSelected == "Menina") ? playerGirlPrefab : playerBoyPrefab;

        // Instancia o personagem escolhido na posição do objeto que contém este script
        GameObject playerInstance = Instantiate(playerPrefabToSpawn, transform.position, Quaternion.identity);

        playerInstance.name = "Player"; // Altera o nome do objeto instanciado para "Player", útil para identificar na cena ou por scripts
    }
}

