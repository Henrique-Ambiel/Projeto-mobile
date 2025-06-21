using UnityEngine;

// Classe utilitária estática para métodos relacionados ao jogador
public static class PlayerUtils
{
    // Método que retorna um prefixo de string com base na skin selecionada pelo jogador
    public static string GetCharacterPrefix()
    {
        string skinSelected = PlayerPrefs.GetString("skinSelected", "Menino"); // Recupera a skin salva no PlayerPrefs, ou "Menino" como valor padrão se não existir

        return (skinSelected == "Menina") ? "Girl" : "Boy"; // Retorna "Girl" se a skin for "Menina", caso contrário, retorna "Boy"
    }
}
