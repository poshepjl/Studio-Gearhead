using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestScript : MonoBehaviour
{
    public bool flag;
    public int i = 1;

    public void Console()
    {
        Debug.Log("Does this even work???");
    }
}

[CustomEditor(typeof(TestScript))]
public class TestScriptEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var testScript = target as TestScript;

        testScript.flag = GUILayout.Toggle(testScript.flag, "Flag");

        if(testScript.flag)
        {
            testScript.i = EditorGUILayout.IntSlider("I Field:", testScript.i, 1, 100);

            if (GUILayout.Button("Button"))
            {
                testScript.Console();
            }
        }
    }
}
