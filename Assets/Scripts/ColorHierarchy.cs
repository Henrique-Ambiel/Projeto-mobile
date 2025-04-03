using UnityEditor;
using UnityEngine;

public class ColorHierarchy : MonoBehaviour
{

    public Color textColor = Color.white;
    public Color backgroundColor = Color.red;

    private void OnValidate()
    {
        //EditorApplication.RepaintHierarchyWindow(); // usa as cores para repintar o ambiente da hierarquia.
    }
}
