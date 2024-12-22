using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    private Vector3 playerMovement;
    private Rigidbody rb;

    public Animator animator;
    public float movSpeed, turnSpeed;
    public bool grounded = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement = new Vector3(Input.GetAxis("Horizontal"),0.0f, Input.GetAxis("Vertical"));

        transform.Rotate(Vector3.up * playerMovement.x * turnSpeed * Time.deltaTime);

        if (playerMovement.z != 0 && grounded)
        {           
            MovePlayer();                
        }
        else
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, 0);
            animator.SetBool("isMoving", false);
        }

// Debug.Log(animator.GetBool("isMoving") + ", " + playerMovement.z);
    }

    private void MovePlayer()
    {
        animator.SetBool("isMoving", true);

        Vector3 movVector = transform.TransformDirection(playerMovement) * movSpeed;        
        rb.linearVelocity = new Vector3(movVector.x, rb.linearVelocity.y, movVector.z); 
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor"){
            grounded = true;            
        }
        else {            
            grounded = false;            
        }        
    }

    private void OnCollisionExit(Collision other)
    {
        grounded = false;
    }
}
