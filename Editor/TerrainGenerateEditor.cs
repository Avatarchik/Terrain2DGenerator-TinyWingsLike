using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Terrain2DGenerator))]
[CanEditMultipleObjects]
public class TerrainGenerateEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Terrain2DGenerator tg = (Terrain2DGenerator)target;
        if (GUILayout.Button("Add Next Point"))
        {
           tg.AddNextPoint(tg.next_Point, tg.number_Of_Point);
           Debug.Log("Clicked");
        }
    }
}
