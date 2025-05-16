using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject prefabBoy;
    public GameObject prefabGirl;

    private GameObject playerInstance;

    void Start()
    {
        string skin = UserData.GetSkin();

        if (skin == "Menino")
        {
            playerInstance = Instantiate(prefabBoy, Vector3.zero, Quaternion.identity);
        }
        else
        {
            playerInstance = Instantiate(prefabGirl, Vector3.zero, Quaternion.identity);
        }
    }
}
