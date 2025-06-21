using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject screenSettings;
    public GameObject screenLibras;
    public Image iconPlayer;
    public Sprite boySprite;
    public Sprite girlSprite;
    [SerializeField] private bool switchSettings = false;
    public TextMeshProUGUI namePlayer;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (PlayerSpawn.PlayerSkin == "Boy") iconPlayer.sprite = boySprite;
        else iconPlayer.sprite = girlSprite;
        namePlayer.text = ScreenCharacter.inputField.text.ToUpper(); // Atualiza o nome do jogador TUDO EM MAIÚSCULO

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void SwitchSetting()
    {
        switchSettings = !switchSettings;

        if (!switchSettings) screenSettings.SetActive(true);
        else screenSettings.SetActive(false);

    }

    public void MenuScreen()
    {
        switchSettings = false; // Reseta o estado do switch
        PlayerSpawn.PlayerSkin = ""; // Limpa a skin do jogador
        ScreenCharacter.inputField.text = ""; // Limpa o campo de texto

        PlayerSpawn.hasSpawned = false; // Reseta o estado de spawn do jogador
        Destroy(player); // Destroi o jogador atual
        SceneManager.LoadScene("MenuScene"); // Carrega a cena do menu
    }

    public void LibrasScreen()
    {
        screenSettings.SetActive(false);
        screenLibras.SetActive(true);
    }
    public void LibrasToMenu()
    {
        screenSettings.SetActive(true);
        screenLibras.SetActive(false);
    }
}
