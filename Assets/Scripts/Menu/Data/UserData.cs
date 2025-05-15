using UnityEngine;

public static class UserData
{
    public const string skinKey = "skinSelecionada";
    public const string nameKey = "nomeJogador";

    // Retorna a skin salva (padrão: "Menino")
    public static string GetSkin()
    {
        return PlayerPrefs.GetString(skinKey, "Menino");
    }

    // Salva o nome do jogador e Salva a skin selecionada
    public static void SetData(string name, string skin)
    {
        PlayerPrefs.SetString(nameKey, name);
        PlayerPrefs.Save();
        PlayerPrefs.SetString(skinKey, skin);
        PlayerPrefs.Save();
    }

    // Retorna o nome salvo
    public static string GetName()
    {
        return PlayerPrefs.GetString(nameKey, "Jogador");
    }
}
