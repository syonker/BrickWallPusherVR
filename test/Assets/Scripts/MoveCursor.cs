using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour {

    public GameObject cam;
    private Vector3 lastVec = new Vector3(0.0f, 0.0f, -1.0f);

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = cam.transform.position + cam.transform.forward*8;

        float angle = Vector3.SignedAngle(lastVec, cam.transform.forward, cam.transform.up);

        transform.rotation = cam.transform.rotation;

       // transform.Rotate(0, angle, 0);

        //transform.Rotate(cam.transform.up, angle);

        lastVec = cam.transform.forward;

    }
}
