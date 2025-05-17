using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerBoyPrefab; // prefab do personagem Boy
    public GameObject playerGirlPrefab; // prefab do personagem Girl

    public Transform spawnPoint; // ponto de spawn do jogador   
    public CinemachineCamera virtualCamera; // arraste sua c�mera aqui no Inspector

    public static string PlayerSkin = ""; // vari�vel est�tica para armazenar a skin do jogador
    private static bool hasSpawned = false; // controle para evitar m�ltiplos spawns

    void Start()
    {
        if (hasSpawned) return; // Se j� tiver spawnado, n�o faz nada

        GameObject prefabToSpawn = null; // Inicializa prefab a null

        if (PlayerSkin == "Boy") // verifica a skin do jogador
            prefabToSpawn = playerBoyPrefab; // instancia o prefab Boy
        else if (PlayerSkin == "Girl") // verifica a skin do jogador
            prefabToSpawn = playerGirlPrefab; // instancia o prefab Girl

        if (prefabToSpawn != null) // se o prefab n�o for nulo
        {
            GameObject playerInstance = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity); // instancia o prefab na posi��o do spawn
            hasSpawned = true; // marca que o jogador foi spawnado

            // faz a Cinemachine seguir o jogador instanciado
            if (virtualCamera != null)
            {
                virtualCamera.Follow = playerInstance.transform; // atribui o jogador � c�mera
                virtualCamera.LookAt = playerInstance.transform; 
            }
            else
            {
                Debug.LogWarning("virtual camera n�o encontrada");
            }
        }
        else
        {
            Debug.LogWarning("nenhum personagem selecionado para o spawn");
        }
    }
}
