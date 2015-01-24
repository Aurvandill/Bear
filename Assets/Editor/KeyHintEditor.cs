using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(KeyHint))]
public class KeyHintEditor : Editor {

	public void OnEnable()
    {
        KeyHint keyHint = (KeyHint)target;
        keyHint.Redraw();
    }

    public override void OnInspectorGUI()
    {
        KeyHint keyHint = (KeyHint)target;

        this.DrawDefaultInspector();
        
        if (GUILayout.Button("Redraw"))
        {
            keyHint.Redraw();
        }
    }
}
