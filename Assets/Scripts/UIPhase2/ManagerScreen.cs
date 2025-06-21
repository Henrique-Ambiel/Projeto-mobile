using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScreen : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
