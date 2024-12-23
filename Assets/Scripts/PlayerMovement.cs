using UnityEngine;
using UnityEngine.UIElements;
//using UnityEngine.Windows;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    private Vector2 playerMovement;
    
    private Animator animatorPlayer;
    public float movSpeed;
    public bool grounded = false, seMueve = false, isAlive;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAlive = true;
        animatorPlayer = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive) { 
            float anguloY = Camera.main.transform.eulerAngles.y;

            transform.rotation = Quaternion.Euler(0, anguloY, 0);
            if (grounded) { 
            transform.position += transform.forward * playerMovement.y * movSpeed * Time.deltaTime;            
            }
            else
            {                
                transform.position += transform.position * 0;
            }
        }
        else{
            print("Dying!");
            Death();
        }

    }

    public void MovePlayer(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            animatorPlayer.SetBool("isMoving", true);
            playerMovement = context.ReadValue<Vector2>();
        }
        else
        {
            animatorPlayer.SetBool("isMoving", false);
            playerMovement = Vector2.zero;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Floor"){
            grounded = true;
        }   
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Floor")
        {
            grounded = false;
        }  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hazards")
        {
            isAlive = false;
        }
    }

    private void Death()
    {
        animatorPlayer.SetBool("isDead", true);
    }
}
