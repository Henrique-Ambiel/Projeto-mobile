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
