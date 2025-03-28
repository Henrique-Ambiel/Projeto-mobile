using UnityEditor;
using UnityEngine;

// NA PASTA EDITOR
public class CustomHierarchyMenu : EditorWindow
{
    [MenuItem("GameObject/Create Custom Header")]

    static void CreateCustomHeader(MenuCommand menuCommand) // menuCommand usado para saber qual objeto está selecionado.
    {
        GameObject obj = new GameObject("Header");

        Undo.RegisterCreatedObjectUndo(obj, "Create Custom Header"); // registra ação do personagem, para que seja possível utilizar undo/crtl+z.

        GameObjectUtility.SetParentAndAlign(obj, menuCommand.context as GameObject); // se selecionado algum objeto, transforma o obj em filho dele.
        obj.AddComponent<ColorHierarchy>();

        Selection.activeObject = obj; // para expandir a hierarquia ao ser criado em um objeto ja existente.
    }
}
