using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBrick : MonoBehaviour {

    private Rigidbody rb;
    public float speed;
    private float x, y, z;
    public bool isActive = false;
    public Material activeMaterial;
    public Material defaultMaterial;

	// Use this for initialization
	void Start () {

        rb = GetComponent< Rigidbody > ();

        x = this.gameObject.transform.position.x;
        z = this.gameObject.transform.position.z;
        y = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (isActive)
        {
            Vector3 direction = new Vector3(x, y, z);
            rb.AddForce(direction * speed);
        }
    }
}
