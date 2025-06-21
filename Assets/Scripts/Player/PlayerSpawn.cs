using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerBoyPrefab;
    public GameObject playerGirlPrefab;

    public CinemachineCamera virtualCamera; // arraste sua câmera aqui no Inspector

    public static string PlayerSkin = "";
    public static bool hasSpawned = false;

    void Start()
    {
        if (hasSpawned) return;

        GameObject prefabToSpawn = null;

        if (PlayerSkin == "Boy")
            prefabToSpawn = playerBoyPrefab;
        else if (PlayerSkin == "Girl")
            prefabToSpawn = playerGirlPrefab;

        if (prefabToSpawn != null)
        {
            GameObject playerInstance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            hasSpawned = true;

            // Atribui PlayerManager ao PuzzleBooksButtons
            PlayerManager pm = playerInstance.GetComponent<PlayerManager>();
            PuzzleBooksButtons puzzleBooks = FindAnyObjectByType<PuzzleBooksButtons>();
            if (puzzleBooks != null && pm != null)
            {
                puzzleBooks.SetPlayerManager(pm);
            }
            else
            {
                Debug.LogError("Não foi possível conectar o PlayerManager ao PuzzleBooksButtons.");
            }
            // Faz a Cinemachine seguir o jogador instanciado
            if (virtualCamera != null)
            {
                virtualCamera.Follow = playerInstance.transform;
                virtualCamera.LookAt = playerInstance.transform; // opcional, se usar LookAt
            }
            else
            {
                Debug.LogWarning("Virtual Camera não atribuída no PlayerSpawn.");
            }
        }
        else
        {
            Debug.LogWarning("Nenhum personagem selecionado para spawn.");
        }
    }
}
