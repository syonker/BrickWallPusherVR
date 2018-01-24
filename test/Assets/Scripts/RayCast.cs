using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RayCast : MonoBehaviour {

    private GameObject prev = null;
    private GameObject curr = null;
    private int count = 0;
    private Scene scene;
    public GameObject cursor;
    public GameObject ground;
    private bool freshStart = true;
    public GameObject cam;
    //private Camera mainCam;

    // Use this for initialization
    void Start () {

        scene = SceneManager.GetActiveScene();

        //mainCam = Camera.ma
		
	}
	
	// Update is called once per frame
	void Update ()
    {


        Vector3 origin = transform.position;
        Vector3 direction = transform.forward;
        RaycastHit hitInfo;

        Ray myRay = new Ray(origin, direction);

        //if we hit something
        if (Physics.Raycast(myRay, out hitInfo, 200.0f))
        {

            

            curr = hitInfo.transform.gameObject;


            if (hitInfo.transform.tag == "Reset")
            {


                //check for starting new
                if (!freshStart)
                {



                    if (prev == null)
                    {
                        //count = 0;

                        prev = curr;
                    }
                    else
                    {

                        count++;


                        if (count < 120)
                        {
                            cursor.GetComponent<Image>().fillAmount = count / 120.0f;
                        }
                        //reset the game
                        else
                        {

                            SceneManager.LoadScene(scene.name);

                        }

                    }

                }


                return;


                /*
                //problem
                if (curr == null)
                {
                    return;

                }

                //.
                prev = null;
                //reset the game
                SceneManager.LoadScene(scene.name);

                return;
                */

            }

            freshStart = false;


            if (hitInfo.transform.tag != "Ground")
            {


           

                //curr = hitInfo.transform.gameObject;

                if ((prev == curr) || (prev == null))
                {
                    //curr.GetComponent<MeshRenderer>().material = curr.GetComponent<PushBrick>().activeMaterial;
                    count++;
                    if (count >= 120)
                    {

                        curr.GetComponent<MeshRenderer>().material = curr.GetComponent<PushBrick>().activeMaterial;

                        if (count == 400)
                        {
                            curr.GetComponent<PushBrick>().speed += 2;

                        }

                        if (count == 800)
                        {
                            curr.GetComponent<PushBrick>().speed += 5;

                        }

                        if (count == 1200)
                        {
                            curr.GetComponent<PushBrick>().speed += 5;

                        }

                        if (count == 1600)
                        {
                            curr.GetComponent<PushBrick>().speed += 10;

                        }

                        if (count == 2000)
                        {
                            curr.GetComponent<PushBrick>().speed += 10;

                        }


                        curr.GetComponent<PushBrick>().isActive = true;
                        //curr.GetComponent<MeshRenderer>().material = curr.GetComponent<PushBrick>().activeMaterial;

                        

                    }


                    if (prev == null)
                    {
                        prev = curr;

                    }


                }
                else
                {

                    if (prev != ground.gameObject)
                    {

                        prev.GetComponent<PushBrick>().isActive = false;
                        prev.GetComponent<MeshRenderer>().material = prev.GetComponent<PushBrick>().defaultMaterial;
                        prev.GetComponent<PushBrick>().speed = 10;

                    }

                    count = 0;
                    prev = curr;


                }


                if (count < 120)
                {
                    cursor.GetComponent<Image>().fillAmount = count / 120.0f;
                }
                else
                {
                    cursor.GetComponent<Image>().fillAmount = 1.0f;
                }


            }
            //teleport
            else
            {

                //if last thing hit was a brick
                if ((prev != null) && (prev != curr))
                {

                    prev.GetComponent<PushBrick>().isActive = false;
                    prev.GetComponent<MeshRenderer>().material = prev.GetComponent<PushBrick>().defaultMaterial;
                    prev.GetComponent<PushBrick>().speed = 10;

                    count = 0;
                    prev = curr;

                }
                else
                {
                    if (prev != null)
                    {
                        count++;
                    } else
                    {
                        prev = curr;
                    }



                    if (count == 480)
                    {

                        prev = null;
                        count = 0;
                        cursor.GetComponent<Image>().fillAmount = 0.0f;

                        Debug.Log("Teleported");

                        float offset = cam.transform.position.y - ground.transform.position.y;

                        Vector3 newPos = new Vector3(hitInfo.point.x, hitInfo.point.y + offset, hitInfo.point.z);

                        //cam.transform.position = hitInfo.point;
                        cam.transform.position = newPos;

                        return;


                    }




                }


                if (count < 480)
                {
                    cursor.GetComponent<Image>().fillAmount = count / 480.0f;
                }
                else
                {
                    cursor.GetComponent<Image>().fillAmount = 1.0f;
                }



            }

            
        }
        //nothing hit
        else
        {

            if (prev != null)
            {
                if ((prev != ground.gameObject) && (prev.transform.tag != "Reset"))
                {
                    prev.GetComponent<PushBrick>().isActive = false;
                    prev.GetComponent<MeshRenderer>().material = prev.GetComponent<PushBrick>().defaultMaterial;
                    prev.GetComponent<PushBrick>().speed = 10;

                }

                cursor.GetComponent<Image>().fillAmount = 0.0f;

                count = 0;
                //prev = ground.gameObject;
                prev = null;

            }

        }

       
        
    }
}
