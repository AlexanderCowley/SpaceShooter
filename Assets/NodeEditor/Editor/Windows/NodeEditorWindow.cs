using UnityEngine;
using UnityEditor;

public class NodeEditorWindow : EditorWindow
{
    public static NodeEditorWindow Window;

    public NodePropertyView PropertyView;
    public NodeWorkView WorkView;

    public NodeGraph currentGraph = null;

    public float viewPercentage = 0.75f;

    public static void CreateWindow()
    {
        Window = (NodeEditorWindow)GetWindow<NodeEditorWindow>();
        Window.titleContent = new GUIContent("Node Editor");
    }

    static void CreateViews()
    {
        if (Window != null)
        {
            Window.WorkView = new NodeWorkView();
            Window.PropertyView = new NodePropertyView();
        }
        else
            Window = GetWindow<NodeEditorWindow>();
    }

    void OnEnable()
    {
        //Called here to prevent error with calling Resources.Load before being enabled
        CreateViews();
    }

    void OnDestroy()
    {
        
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        if (PropertyView == null || WorkView == null)
        {
            CreateViews();
            return;
        }

        Event e = Event.current;
        ProcessEvents(e);
        WorkView.UpdateView(position, new Rect(0f, 0f, viewPercentage, 1f), e, currentGraph);

        PropertyView.UpdateView(new Rect(position.width, position.y, position.width, position.height),
            new Rect(viewPercentage, 0f, 1f - viewPercentage, 1f), e, currentGraph);

        Repaint();
    }

    void ProcessEvents(Event e)
    {
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.LeftArrow)
            viewPercentage -= 0.01f;
        if (e.type == EventType.KeyDown && e.keyCode == KeyCode.RightArrow)
            viewPercentage += 0.01f;
    }
}