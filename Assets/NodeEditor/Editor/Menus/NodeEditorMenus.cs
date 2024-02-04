using UnityEngine;
using UnityEditor;
public static class NodeEditorMenus
{
    [MenuItem("Node Editor/Launch Editor")]
    public static void InitNodeGraph()
    {
        NodeEditorWindow.CreateWindow();
    }
}