using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuInGameManager : MonoBehaviour
{
    [SerializeField] private bool isSettings = false;
    [SerializeField] private GameObject screenSettings;
    public GameObject player;
    public TMP_Text userNameText;
    public Image profilePicture;
    public Sprite boySprite;
    public Sprite girlSprite;

    void Start()
    {
        // Corrigido: usa método para obter o nome
        userNameText.text = UserData.GetName();

        // Corrigido: usa método para obter a skin
        if (UserData.GetSkin().ToLower() == "menino")
            profilePicture.sprite = boySprite;
        else if (UserData.GetSkin().ToLower() == "menina")
            profilePicture.sprite = girlSprite;
    }

    public void SwitchSettings()
    {
        isSettings = !isSettings;
        screenSettings.SetActive(isSettings);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
