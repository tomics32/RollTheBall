using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonMovement : MonoBehaviour
{
    
    public Transform cam;

    public Rigidbody rb;

    public float speed = 10f;
    private float xInput;
    private float zInput;

    public LayerMask groundLayers;
    public float jumpForce = 10f;
    public SphereCollider col;

    public float maxSpeed = 4f;

    // Rolling sound

    public AudioSource rollBall;
    int startingPitch = 4;
    float volumeSpeed = 4.5f;



    public void Awake()
    {
        
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }
    void Update()
    {
        ProcessInputs();
        Jump();
        
    }
    void FixedUpdate()
    {
      

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        rollBall.volume = Mathf.Clamp01(rb.velocity.magnitude / volumeSpeed);
        rollBall.pitch = Mathf.Clamp(rb.velocity.magnitude / startingPitch, 0.1f, 2);
        Move();
        
    }

    
    void OnCollisionStay(Collision collision)
    {
        if (rollBall.isPlaying == false && rb.angularVelocity.magnitude >= 0.5f && collision.gameObject.tag == "Ground")
        {       
            rollBall.Play();
        }
        else if (rollBall.isPlaying == true && rb.angularVelocity.magnitude < 0.5f && collision.gameObject.tag == "Ground")
        {
            rollBall.Pause();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (rollBall.isPlaying == true && collision.gameObject.tag == "Ground")
        {
            rollBall.Pause();
        }
    }
    private void ProcessInputs()
    {
        
            xInput = Input.GetAxis("Horizontal");
            zInput = Input.GetAxis("Vertical");

    }
    private void Move()
    {
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.AddForce(moveDir * speed);
        }
    }

    
    

    private void Jump()
    {
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            gameObject.GetComponent<AudioSource>().Play();
            
        }
    }

    private bool isGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
        
    }


	

}
