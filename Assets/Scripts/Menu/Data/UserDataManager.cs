using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UserDataManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public string selectedSkin = "Menino"; // valor padrão

    // Chamado ao clicar em "SALVAR E INICIAR"
    public void SaveUserData()
    {
        string name = nameInput.text;
        UserData.SetData(name, selectedSkin);
        Debug.Log("Dados salvos: " + name + ", " + selectedSkin);

        SceneManager.LoadScene("GameplayScene");
    }

    // Chamado ao clicar no botão do menino
    public void SelectBoy()
    {
        selectedSkin = "Menino";
        Debug.Log("Skin selecionada: Menino");
    }

    // Chamado ao clicar no botão da menina
    public void SelectGirl()
    {
        selectedSkin = "Menina";
        Debug.Log("Skin selecionada: Menina");
    }
}
