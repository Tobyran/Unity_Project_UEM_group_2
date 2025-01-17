using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    private BarraVida logicaBarraVidaJugador;
    private bool hit = false;

    public ParticleSystem parts;
    public GameObject bullet;
    public float speed, damage, maxLife, count;
    // Update is called once per frame

    private void Start()
    {
        
    }

    void Update()
    {
        count += Time.deltaTime;
        if (!hit) { 
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (hit || count >= maxLife) 
        {
            transform.Translate(Vector3.zero);
            bullet.SetActive(false);
            if (parts != null)
            {
                var main = parts.main;
                main.maxParticles = 0;
            }

            Destroy(gameObject, 1.0f);
        }       

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.transform.CompareTag("Player") && !hit)
            {
                logicaBarraVidaJugador = other.gameObject.GetComponent<BarraVida>();
                logicaBarraVidaJugador.vidaActual -= damage;
                hit = true;
            }
            else if(!hit){
                hit = true;
            }
        }
    }
}
