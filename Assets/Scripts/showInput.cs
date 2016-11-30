using UnityEngine;
using System.Collections;

public class showInput : MonoBehaviour {
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), "x=" + Input.acceleration.x + "   y=" + Input.acceleration.y + "   z=" + Input.acceleration.z);
    }
}
