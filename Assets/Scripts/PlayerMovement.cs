using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float flaps = 0;
    float speed = 20f;
    float glideSpeed = 25f;
    float flapHeight = 2f;
    Vector3 flapVector;
    Vector3 glideVector;
    int pressed = 0;
    float xRot = 0.2f;
    float rotationSpeed = 70f;
    bool lost = false;
    public CharacterController controller;
    public Animator anim;
    Quaternion originalRotation;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        originalRotation = transform.rotation;
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
            anim.Play("FlapForward");
            anim.SetInteger("condition", 1);


        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetInteger("condition", 0);
        }
    }


    void glide()
    {
        if(Input.GetKey(KeyCode.E) && !lost)
        {



            anim.SetInteger("condition", 2);

            glideVector = (Vector3.forward  - Vector3.up).normalized * glideSpeed;
            GetComponent<Rigidbody>().velocity = glideVector;
            
         
                
            transform.Rotate(xRot, 0f, 0f);
            Debug.Log("Gliding.");
            glideSpeed += 0.2f;
            anim.Play("GlideForward");

        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            // glideSpeed = 3f;

            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed);
           // anim.Play("HoverUp");
            anim.SetInteger("condition", 3);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        speed = 0f;
        glideSpeed = 0f;
        Debug.Log("You lost.");
        lost = true;
    }
}
