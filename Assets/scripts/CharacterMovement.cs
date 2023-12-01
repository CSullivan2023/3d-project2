using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

   [SerializeField] float maxSpeed = 1.0f;
    [SerializeField] float rotation = 0.0f;
    [SerializeField] float camRotation = 0;
    [SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float camRotationSpeed = 1.5f;
    GameObject cam;
    [SerializeField]  Animator myAnim;

    

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();
        myAnim.SetFloat("speed", rb.velocity.magnitude);

        rb = GetComponent<Rigidbody>();

        cam = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

       
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            myAnim.SetTrigger("jumped");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotationSpeed, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
       
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
        
    }
}
