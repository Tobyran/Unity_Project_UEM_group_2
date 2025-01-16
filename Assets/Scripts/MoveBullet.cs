using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private BarraVida logicaBarraVidaJugador;
    
    public float speed, damage, maxLife, count;
    // Update is called once per frame

    void Update()
    {
        count += Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (count >= maxLife)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            logicaBarraVidaJugador = collision.gameObject.GetComponent<BarraVida>();
            logicaBarraVidaJugador.vidaActual -= damage;
            Destroy(gameObject);
        }  
    }
}
