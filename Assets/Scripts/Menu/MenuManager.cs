using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string gameplayLevelName;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject configPanel;


    //Botão que inicia o jogo 
    public void Play()
    {
       SceneManager.LoadScene(gameplayLevelName);
       Debug.Log("Jogo iniciado");
    }

    //Botão que abre a tela de configurações
    public void OpenConfig()
    {
        menuPanel.SetActive(false);
        configPanel.SetActive(true);
        Debug.Log("Configurações abertas");
    }

    //Botão que fecha a tela de configurações
    public void CloseConfig()
    {
        configPanel.SetActive(false);
        menuPanel.SetActive(true);
        Debug.Log("Configurações desligadas");
    }

    //Botão que fecha o jogo
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}
