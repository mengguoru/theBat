using UnityEngine;
using System.Collections;

public class AccelerometerInput : MonoBehaviour {
    public float speed = 20f;
    public GameObject bat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.acceleration.x;
        float z = Input.acceleration.z;
        transform.Translate(0, 0, -z * speed * Time.deltaTime);
        bat.gameObject.transform.Rotate(0, 0, -x * speed * Time.deltaTime);
	}
}
