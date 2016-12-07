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
        theBat = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float hori = CrossPlatformInputManager.GetAxis("Horizontal");
        float veri = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 flightOffset = new Vector3(hori * speed * Time.deltaTime, veri *speed * Time.deltaTime, flightForce * Time.deltaTime);
        //transform.Translate(hori, veri, flightForce*Time.deltaTime);
        transform.position += flightOffset;
        Debug.Log(hori + ":"+veri);
        //theBat.transform.Rotate(hori* rotateSpeed, veri*rotateSpeed, 0);
        //theBat.transform.Rotate(hori * rotateSpeed * Time.deltaTime, veri * rotateSpeed * Time.deltaTime, 0);
    }
}
