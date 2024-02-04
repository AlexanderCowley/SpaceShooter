using UnityEngine;
using UnityEditor;
public class NodePopUpWindow : EditorWindow
{
    static NodePopUpWindow Window;
    string wantedName = "Enter a name...";

    public static void InitPopUp()
    {
        Window = (NodePopUpWindow)GetWindow<NodePopUpWindow>();
        Window.titleContent= new GUIContent("Node Popup");
    }

    void OnGUI()
    {
        GUILayout.Space(20);
        GUILayout.BeginHorizontal();
        GUILayout.Space(20);

        GUILayout.BeginVertical();
        EditorGUILayout.LabelField("Create new Graph: ", EditorStyles.boldLabel);
        wantedName = EditorGUILayout.TextField("Enter Name Here: ", wantedName);
        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Create Graph", GUILayout.Height(40)))
        {
            if(!string.IsNullOrEmpty(wantedName) && wantedName != "Enter a name...")
            {
                NodeUtility.CreateGraph(wantedName);
                Window.Close();
            }
            else
            {
                EditorUtility.DisplayDialog("Node Message", "Please Enter a valid graph name!", "OK");
            }
        }

        if (GUILayout.Button("Cancel", GUILayout.Height(40)))
        {
            Window.Close();
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.Space(20);
        GUILayout.EndHorizontal();
        GUILayout.Space(20);
    }

}