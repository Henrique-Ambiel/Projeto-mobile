using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerBoyPrefab;
    public GameObject playerGirlPrefab;

    void Start()
    {
        string skinSelecionada = PlayerPrefs.GetString("skinSelecionada", "Menino");

        GameObject playerPrefabToSpawn = (skinSelecionada == "Menina") ? playerGirlPrefab : playerBoyPrefab;

        GameObject playerInstance = Instantiate(playerPrefabToSpawn, transform.position, Quaternion.identity);

        // (Opcional) marca como "Player" ou define tag para outras interações
        playerInstance.name = "Player";
    }
}
