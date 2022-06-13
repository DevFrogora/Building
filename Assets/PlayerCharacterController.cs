using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : MonoBehaviour
{
    public float rayCastHeightOffset;

    Rigidbody rb;
    public bool isGrounded;
    Vector3 targetPosition;


    CapsuleCollider capsuleCollider;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }


    private void Update()
    {
        //CheckGrounded();
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        Vector3 rayCastOrigin = transform.position;
        targetPosition = transform.position;
        rayCastOrigin.y += rayCastHeightOffset;
        if(Physics.Raycast(rayCastOrigin, -Vector3.up,out hit))
        {
            Debug.DrawLine(rayCastOrigin, hit.point, Color.cyan);

            //Debug.DrawLine(transform.position, hit.point);
            //Debug.Log(hit.distance);

            if (hit.distance < (rayCastHeightOffset + 0.1))
            {
                //Debug.Log(hit.distance);

                targetPosition.y = hit.point.y;
                isGrounded = true;
                rb.useGravity = false ;

            }
            else
            {
                isGrounded = false;
            }
        }
        

        if (isGrounded)
        {
            transform.position = targetPosition; 
            rb.velocity = Vector3.zero;
            
        }
        if(!isGrounded)
        {
            rb.useGravity = true;
        }
    }
    public bool incomingInput;

    public void Move(Vector3 move)
    {
        
        if (move != Vector3.zero)
        {
            transform.position += move;

        }

        if(!incomingInput)
        {

            Debug.Log("No incoming input");
            CheckGrounded();
        }


    }

    public IEnumerator waitForSecond()
    {
        isGrounded = false;
        incomingInput = true;
        yield return new WaitForSeconds(0.5f);
        incomingInput = false;
        isGrounded = true;

    }
}
