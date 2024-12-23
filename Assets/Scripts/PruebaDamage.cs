using UnityEngine;

public class PruebaDamage : MonoBehaviour
{

    public BarraVida logicaBarraVidaJugador;
    public BarraVida logicaBarraVidaNPC;
    private Collision collision;

    public float damage = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (collision.transform.CompareTag("Bullet")) 
        {
            logicaBarraVidaJugador.vidaActual -= damage;
            Destroy(collision.gameObject);
        }
    }
}
