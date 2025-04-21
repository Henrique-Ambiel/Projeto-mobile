using UnityEngine;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour
{
    [SerializeField] private string gameplayLevelName;

    //Botão que inicia o jogo 
    public void Play()
    {
        SceneManager.LoadScene(gameplayLevelName);
        Debug.Log("Jogo Iniciado");
    }
}
