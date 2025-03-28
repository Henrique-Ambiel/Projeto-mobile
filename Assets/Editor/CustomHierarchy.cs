
using UnityEditor;
using UnityEngine;

// NA PASTA EDITOR
[InitializeOnLoad]
public class CustomHierarchy
{
    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += RenderObjects; // sempre que a UI da hierarquia mudar, chama o metodo RenderObjects.
    }

    private static void RenderObjects(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject; // converte instanceID para um objeto.
        if (gameObject == null) return;

        if (gameObject.TryGetComponent<ColorHierarchy>(out var customObjectColor))
        {
            EditorGUI.DrawRect(selectionRect, customObjectColor.backgroundColor); // desenha a cor de fundo.
            EditorGUI.LabelField(selectionRect, gameObject.name.ToUpper(), new GUIStyle() // muda as configurações da fonte
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold,
                normal = new GUIStyleState()
                {
                    textColor = customObjectColor.textColor,
                }
            });
        }
    }
}
