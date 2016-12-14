using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class DrawCircleScreenPos : MonoBehaviour {

	public Material mat;
    public Transform target;
    public Vector3 screenPos;
    public Camera cam;
    //handle wave frequence
    public float delayTime;
    private float timer;
    //for disappear 
    float disappearGrid = 0;

	void Start () {
        cam = this.GetComponent<Camera>();
        screenPos = cam.WorldToViewportPoint(target.position);

        mat.SetFloat("_CenterX", screenPos.x);
        mat.SetFloat("_CenterY", 1 - screenPos.y);

        timer = delayTime;
    }

	void Update (){
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    //set _StartingTime to current time
        //    mat.SetFloat("_StartingTime", Time.time);
        //    //set _RunRingPass to 1 to start the ring
        //    mat.SetFloat("bRunPass", 1);
        //    StartCoroutine(WaitForClear(3));
        //}

        //mat.SetFloat("_StartingTime", Time.time);
        ////set _RunRingPass to 1 to start the ring
        //mat.SetFloat("bRunPass", 1);
        //StartCoroutine(WaitForClear(3));
        //StartCoroutine(WaitForWave(3));
        if(delayTime +0.1 < timer)
        {
            startWave();
            timer = 0;
        }else
        {
            timer += Time.deltaTime;
            //for disappear
            disappearGrid = (Mathf.Floor(timer / (delayTime / 5)));
            mat.SetFloat("disapearGrid", (float)0.36*disappearGrid);
        }
    }

	// Called by the camera to apply the image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination){
	   //mat is the material containing your shader
	   Graphics.Blit(source,destination,mat);
	}

    void startWave()
    {
        mat.SetFloat("_StartingTime", Time.time);
        //set _RunRingPass to 1 to start the ring
        mat.SetFloat("bRunPass", 1);
        StartCoroutine(WaitForClear(3));
        mat.SetFloat("disapearGrid", 0);
    }

    IEnumerator WaitForClear(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            mat.SetFloat("bRunPass", 0);
        }
    }

    IEnumerator WaitForWave(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            mat.SetFloat("_StartingTime", Time.time);
            //set _RunRingPass to 1 to start the ring
            mat.SetFloat("bRunPass", 1);
            StartCoroutine(WaitForClear(3));
        }
    }
}