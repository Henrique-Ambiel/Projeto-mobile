using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerBoyPrefab; // prefab do personagem Boy
    public GameObject playerGirlPrefab; // prefab do personagem Girl

    public Transform spawnPoint; // ponto de spawn do jogador   
    public CinemachineCamera virtualCamera; // arraste sua câmera aqui no Inspector

    public static string PlayerSkin = ""; // variável estática para armazenar a skin do jogador
    private static bool hasSpawned = false; // controle para evitar múltiplos spawns

    void Start()
    {
        if (hasSpawned) return; // Se já tiver spawnado, não faz nada

        GameObject prefabToSpawn = null; // Inicializa prefab a null

        if (PlayerSkin == "Boy") // verifica a skin do jogador
            prefabToSpawn = playerBoyPrefab; // instancia o prefab Boy
        else if (PlayerSkin == "Girl") // verifica a skin do jogador
            prefabToSpawn = playerGirlPrefab; // instancia o prefab Girl

        if (prefabToSpawn != null) // se o prefab não for nulo
        {
            GameObject playerInstance = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity); // instancia o prefab na posição do spawn
            hasSpawned = true; // marca que o jogador foi spawnado

            // faz a Cinemachine seguir o jogador instanciado
            if (virtualCamera != null)
            {
                virtualCamera.Follow = playerInstance.transform; // atribui o jogador à câmera
                virtualCamera.LookAt = playerInstance.transform; 
            }
            else
            {
                Debug.LogWarning("virtual camera não encontrada");
            }
        }
        else
        {
            Debug.LogWarning("nenhum personagem selecionado para o spawn");
        }
    }
}
