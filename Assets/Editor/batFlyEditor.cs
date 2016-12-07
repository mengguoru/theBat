using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(batFly))]
public class batFlyEditor : Editor {

    private void OnSceneGUI()
    {
        batFly t = target as batFly;
        if (null == t)
            return;

        Handles.color = Color.blue;
        Handles.DrawLine(t.camPos, t.targetPos);
        Handles.DrawWireDisc(t.targetPos, (t.camPos - t.targetPos), t.radius);
    }
}
