using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float flaps = 0;
    float speed = 15f;
    float glideSpeed = 500f;
    float flapHeight = 2f;
    Vector3 flapVector;
    Vector3 glideVector;
    int pressed = 0;
    float xRot = 0.2f;
    public CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
        v =  (Vector3.up + Vector3.forward).normalized * speed;
        GetComponent<Rigidbody>().velocity = v;
        */
    }

    // Update is called once per frame
    void Update()
    {
        flap();
        glide();
       // transform.Rotate(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
    }




    void flap()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            /*transform.Rotate(flaps * Time.deltaTime * speed, 0.0f, 0.0f);
            transform.position += transform.forward * Time.deltaTime * speed;
            transform.position = 
            flaps = flaps - 0.3f;'
            */
            flapVector = (Vector3.up + Vector3.forward).normalized * speed;
            GetComponent<Rigidbody>().velocity = flapVector;


        }
    }


    void glide()
    {
        if(Input.GetKey(KeyCode.E))
        {





            glideVector = (Vector3.forward * glideSpeed - Vector3.up).normalized;
            GetComponent<Rigidbody>().velocity = glideVector;
                
            transform.Rotate(xRot, 0f, 0f);
            Debug.Log("Gliding.");
            glideSpeed += 2f;
            
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            glideSpeed = 3f;
           
            transform.Rotate(0f, 0f, 0f);
        }


    }
}
