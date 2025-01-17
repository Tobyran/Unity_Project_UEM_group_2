using Unity.VisualScripting;
using UnityEngine;

public class LogicaPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 6.0f, velocidadRotacion = 100.0f, x, y, attackCooldown, maxWaitCooldown;
    public Transform spawnpoint;
    public GameObject power;

    private Animator animator;
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

        animator.SetFloat("Velx", x);
        animator.SetFloat("Vely", y);

        if (Input.GetKeyDown(KeyCode.Q) && !estoyAtacando)
        {
            animator.SetTrigger("Golpeo");
            Atacar();                     
        }

        if (estoyAtacando) {
            
            attackCooldown += Time.deltaTime;

            if(attackCooldown > maxWaitCooldown)
            {
                attackCooldown = 0;
                DejeDeGolpear();
            }
        }
    }

    public void DejeDeGolpear()
    {
        estoyAtacando = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    void Atacar()
    {
        estoyAtacando = true;
        GameObject balaNueva = Instantiate(power, spawnpoint.position, spawnpoint.rotation);        
    }

}
