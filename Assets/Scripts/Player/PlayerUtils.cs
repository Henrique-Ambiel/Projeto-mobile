using UnityEngine;

public static class PlayerUtils
{
    public static string GetCharacterPrefix()
    {
        string skinSelected = PlayerPrefs.GetString("skinSelected", "Menino");
        return (skinSelected == "Menina") ? "Girl" : "Boy";
    }
}
