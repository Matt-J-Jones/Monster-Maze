using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveForce = 10f;
    public float turnAngle = 90f;
    public bool canMove = true;
    private Rigidbody rb;
    public float raycastDistance = 1f;
    public AudioSource StepSource;
    public AudioClip StepClip;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
         if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // transform.Translate(Vector3.forward * moveDistance);
                Move(Vector3.forward);
                // canMove = false;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // transform.Translate(Vector3.back * moveDistance);
                Move(Vector3.back);
                // canMove = false;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // transform.Rotate(0, turnAngle * -1, 0);
                Rotate(-turnAngle);
                // canMove = false;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // transform.Rotate(0, turnAngle, 0);
                Rotate(turnAngle);
                // canMove = false;
            }
        }

        if(!Input.GetKeyDown(KeyCode.W) || !Input.GetKeyDown(KeyCode.S) || !Input.GetKeyDown(KeyCode.UpArrow) || !Input.GetKeyDown(KeyCode.DownArrow))
        {
            canMove = true;
        }

        if(!Input.GetKeyDown(KeyCode.A) || !Input.GetKeyDown(KeyCode.D) || !Input.GetKeyDown(KeyCode.LeftArrow) || !Input.GetKeyDown(KeyCode.RightArrow))
        {
            canMove = true;
        }
    }

    void Move(Vector3 direction)
    {
        {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), out hit, raycastDistance))
        {
            if (hit.collider != null && !hit.collider.isTrigger)
            {
                // There's an obstacle, do not move
                Debug.Log("Cannot move. Obstacle detected.");
                return;
            }
        }

        transform.Translate(direction * moveForce);
        StepSource.PlayOneShot(StepClip);
        canMove = false;
    }
    }

    void Rotate(float angle)
    {
        transform.Rotate(0, angle, 0);
        canMove = false;
    }
}
