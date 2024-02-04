using UnityEngine;
using UnityEditor;

public static class NodeUtility
{
    public static NodeGraph CreateGraph(string graphName)
    {
        NodeGraph currentGraph = (NodeGraph)ScriptableObject.CreateInstance<NodeGraph>();

        if (currentGraph == null)
        {
            EditorUtility.DisplayDialog("Node Message", "Unable to create a new graph", "OK");
            return null;
        }
        currentGraph.GraphName = graphName;
        currentGraph.InitGraph();

        AssetDatabase.CreateAsset(currentGraph, "Assets/NodeEditor/Database/" + graphName + ".asset");
        //Saves all unsaved changes to disc!
        AssetDatabase.SaveAssets();
        //For immediate change after saving
        AssetDatabase.Refresh();

        NodeEditorWindow nodeEditorWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();

        if(nodeEditorWindow != null)
            nodeEditorWindow.currentGraph = currentGraph;

        return currentGraph;
    }

    public static void CreateNode(NodeGraph nodeGraph, NodeType type, Vector2 mousePosition)
    {
        if (nodeGraph == null)
            return;

        NodeBase currentNode = null;
        switch(type)
        {
            case NodeType.Float:
                currentNode = (FloatNode)ScriptableObject.CreateInstance<FloatNode>();
                break;

            case NodeType.Add:
                currentNode = (AddNode)ScriptableObject.CreateInstance<AddNode>();
                break;

            default:
                break;
        }

        if (nodeGraph != null)
        {
            currentNode.InitNode();
            currentNode.NodeRect.x = mousePosition.x;
            currentNode.NodeRect.y = mousePosition.y;
            currentNode.ParentGraph = nodeGraph;
            nodeGraph.nodes.Add(currentNode);

            AssetDatabase.AddObjectToAsset(currentNode, nodeGraph);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    public static void LoadGraph()
    {
        NodeGraph nodeGraph = null;
        string graphPath = EditorUtility.OpenFilePanel("Load Graph", Application.dataPath + "/NodeEditor/Database/", "");

        int appPathLength = Application.dataPath.Length;

        //substracts 6 to retain "Assets"
        string finalPath = graphPath.Substring(appPathLength-6);

        nodeGraph = (NodeGraph)AssetDatabase.LoadAssetAtPath(finalPath, typeof(NodeGraph));

        if(nodeGraph == null)
        {
            EditorUtility.DisplayDialog("Node Message", "Unable to load selected graph!", "OK");
        }
        else
        {
            NodeEditorWindow nodeEditorWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
            if (nodeEditorWindow != null)
                nodeEditorWindow.currentGraph = nodeGraph;
        }
    }

    public static void UnloadGraph()
    {
        NodeEditorWindow nodeEditorWindow = (NodeEditorWindow)EditorWindow.GetWindow<NodeEditorWindow>();
        if(nodeEditorWindow != null)
            nodeEditorWindow.currentGraph = null;
    }
    //Probably change this passing in the actual node
    public static void DeleteNode(int nodeID, NodeGraph currentGraph)
    {
        if(currentGraph != null)
        {
            if(currentGraph.nodes.Count >= nodeID)
            {
                NodeBase deleteNode = currentGraph.nodes[nodeID];
                if (deleteNode != null)
                {
                    currentGraph.nodes.RemoveAt(nodeID);
                    GameObject.DestroyImmediate(deleteNode, true);
                    AssetDatabase.SaveAssets();
                    AssetDatabase.Refresh();
                }
            }
        }
    }

    public static void DrawGrid(Rect viewRect, float gridSpace, float gridOpacity, Color gridColor)
    {
        int widthDivs = Mathf.CeilToInt(viewRect.width/gridSpace);
        int heightDivs = Mathf.CeilToInt(viewRect.height/gridSpace);

        Handles.BeginGUI();
        Handles.color = new Color(gridColor.r, gridColor.g, gridColor.b, gridOpacity);

        for(int x = 0; x < widthDivs; x++)
        {
            Handles.DrawLine(new Vector3(gridSpace * x, 0, 0), new Vector3(gridSpace * x, viewRect.height, 0f));
        }

        for (int y = 0; y < heightDivs; y++)
        {
            Handles.DrawLine(new Vector3(0, gridSpace * y, 0), new Vector3(viewRect.width, gridSpace * y, 0f));
        }
        //To avoid inheriting the colors opacity change*
        Handles.color = Color.white;
        Handles.EndGUI();
    }
}