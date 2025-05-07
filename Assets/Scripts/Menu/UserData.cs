using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserData : MonoBehaviour
{
    [SerializeField] private string gameplayLevelName;
    public InputField userNameInput;
    public Button boyButton;
    public Button girlButton;
    public Image boyImage;
    public Image girlImage;

    private string selectedSkin = "";
    public static string userName;
    public static string skin;

    private void Start()
    {
        boyButton.onClick.AddListener(() => SelectSkin("Menino"));
        girlButton.onClick.AddListener(() => SelectSkin("Menina"));
    }

    void SelectSkin(string skin)
    {
        selectedSkin = skin;

        boyImage.gameObject.SetActive(selectedSkin == "Menino");
        girlImage.gameObject.SetActive(selectedSkin == "Menina");
    }


    //Botão que inicia o jogo 
    public void Play()
    {
        if (string.IsNullOrEmpty(userNameInput.text) || string.IsNullOrEmpty(selectedSkin))
        {
            Debug.LogWarning("Preencha todos os campos");
            return;
        }

        userName = userNameInput.text;
        skin = selectedSkin;

        DontDestroyOnLoad(this.gameObject);


        SceneManager.LoadScene(gameplayLevelName);
        Debug.Log("Jogo Iniciado");
    }
}
