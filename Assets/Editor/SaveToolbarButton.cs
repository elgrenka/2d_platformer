using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Toolbars;
using UnityEngine;

public static class SaveToolbarButton
{
    [MainToolbarElement("Мои/Сохранить",                          // путь в контекстном меню тулбара
        defaultDockPosition = MainToolbarDockPosition.Middle,      // средняя секция, где Play
        defaultDockIndex = 105)]                                   // >100, т.к. до 100 занято встроенным
    public static MainToolbarElement CreateSaveButton()
    {
        Texture2D icon = EditorGUIUtility.IconContent("SaveActive").image as Texture2D;
        var content = new MainToolbarContent(icon, "Сохранить сцену и ассеты");
        return new MainToolbarButton(content, () =>
        {
            AssetDatabase.SaveAssets();            // сохранить ассеты
            EditorSceneManager.SaveOpenScenes();   // сохранить открытые сцены
        });
    }
}