using UnityEngine;
using System.Collections;

public class batFly : MonoBehaviour {
    public Vector3 camPos;
    public GameObject target;
    public Vector3 targetPos;
    public Vector3 offset;
    public float radius;

	// Use this for initialization
	void Start () {
        camPos = this.transform.position;
        offset = target.transform.position - camPos;
	}
	
	// Update is called once per frame
	void Update () {
        camPos = this.transform.position;
        targetPos = camPos + offset;
    }
}
