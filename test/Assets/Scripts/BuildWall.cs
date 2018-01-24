using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildWall : MonoBehaviour {

    public GameObject firstParent;
    public float radius = 11;
	// Use this for initialization
	void Start () {

        GameObject newBrick;
        float x = 0;
        float y = 0;
        float z = 0;
        float angle = 10;
        float increment = 6;
        float initialAngle = 0;
        float maxAngle = 360;
        Vector3 newPos;

        for (y = 0; y < 10; y++)
        {

            for (angle = initialAngle; angle < maxAngle; angle+= increment)
            {

                if ((y==0) && (angle==0))
                {
                    continue;
                }

                newBrick = Instantiate(firstParent.gameObject, firstParent.transform.parent, true);

                x = radius * Mathf.Cos((Mathf.PI / 180)*(angle));
                z = radius * Mathf.Sin((Mathf.PI / 180)*(angle));
                newPos = new Vector3(x, y, z);
                newBrick.transform.position = newPos;
     
                newBrick.transform.Rotate(0, -angle, 0);

            }

            initialAngle += (increment / 2);
            maxAngle += (increment / 2);


        }

        


		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
