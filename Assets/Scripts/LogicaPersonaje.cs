using Unity.VisualScripting;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 6.0f;
    public float velocidadRotacion = 100.0f;
    private Animator animator;
    public float x, y;
    private Rigidbody rb;
    public bool estoyAtacando;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Q) && !estoyAtacando)
        {
            animator.SetTrigger("Golpeo");
            estoyAtacando = true;
        }

        animator.SetFloat("Velx", x);
        animator.SetFloat("Vely", y);

    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
        }
    }

}
