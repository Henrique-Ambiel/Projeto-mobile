using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInGameManager : MonoBehaviour
{
    [SerializeField] private bool isSettings = false;
    [SerializeField] private GameObject screenSettings;
    public GameObject player;
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
