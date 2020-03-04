using UnityEngine;
using UnityEditor;

public class EditorUtils : Editor
{
    //This code is released under the MIT license: https://opensource.org/licenses/MIT
    //Sources: https://forum.unity.com/threads/rel-collapse-all-gameobjects-recursively-in-hierarchy-view.298914/
    //https://answers.unity.com/questions/656869/index.html#comment-858132
    [MenuItem("Window/Fold all")]
    [MenuItem("GameObject/Collapse", false, -1)]
    static void UnfoldSelection()
    {
        EditorApplication.ExecuteMenuItem("Window/General/Hierarchy");
        var hierarchyWindow = EditorWindow.focusedWindow;
        var expandMethodInfo = hierarchyWindow.GetType().GetMethod("SetExpandedRecursive");
        foreach (GameObject root in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            expandMethodInfo.Invoke(hierarchyWindow, new object[] { root.GetInstanceID(), false });
        }
    }
}
