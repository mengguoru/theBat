using UnityEngine;
using System.Collections;

public class FieldOfSeeing : MonoBehaviour {
    //public Vector3 pos;
    //public float size;
	// Use this for initialization
	void Start () {
        //pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(20, 10, 20));
    }
}
