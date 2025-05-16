using UnityEngine;

// Esta classe � respons�vel por instanciar o personagem selecionado pelo jogador no in�cio da cena
public class PlayerSpawn : MonoBehaviour
{
    // Prefab do menino e da menina
    public GameObject playerBoyPrefab;
    public GameObject playerGirlPrefab;

    // M�todo chamado automaticamente quando o jogo inicia
    void Start()
    {
        string skinSelected = PlayerPrefs.GetString("skinSelecionada", "Menino");  // Recupera a skin selecionada salva no PlayerPrefs (padr�o: "Menino" caso n�o exista)

        // Escolhe o prefab correspondente com base na skin selecionada usando operador tern�rio
        GameObject playerPrefabToSpawn = (skinSelected == "Menina") ? playerGirlPrefab : playerBoyPrefab;

        // Instancia o personagem escolhido na posi��o do objeto que cont�m este script
        GameObject playerInstance = Instantiate(playerPrefabToSpawn, transform.position, Quaternion.identity);

        playerInstance.name = "Player"; // Altera o nome do objeto instanciado para "Player", �til para identificar na cena ou por scripts
    }
}

