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
    public Sprite meninoSprite;
    public Sprite meninaSprite;

    void Start()
    {
        userNameText.text = UserData.userName;

        if (UserData.skin == "menino")
            profilePicture.sprite = meninoSprite;
        else if (UserData.skin == "menina")
            profilePicture.sprite = meninaSprite;
    }

    public void  SwitchSettings()
    {
        isSettings = !isSettings;


        screenSettings.SetActive(isSettings);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

}
