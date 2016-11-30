using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class bat : MonoBehaviour {
    public float speed;

    public GameObject theBat;
    public float rotateSpeed;

    //simulate flight force
    public float flightForce;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float hori = CrossPlatformInputManager.GetAxis("Horizontal") * speed * Time.deltaTime;
        //Debug.Log(hori);
        float veri = CrossPlatformInputManager.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(hori, veri, flightForce*Time.deltaTime);
        //theBat.transform.Rotate(hori* rotateSpeed, veri*rotateSpeed, 0);
        //theBat.transform.Rotate(hori * rotateSpeed * Time.deltaTime, veri * rotateSpeed * Time.deltaTime, 0);
    }
}
