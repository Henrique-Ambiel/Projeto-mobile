using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string userDataName;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject configPanel;


    //Botão que vai para tela de dados do usuário
    public void DataName()
    {
       SceneManager.LoadScene(userDataName);
       Debug.Log("Escolha o nome do usuário");
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
