using UnityEngine;

public class Hazards : MonoBehaviour
{
    public BarraVida logicaBarraVidaJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            logicaBarraVidaJugador.vidaActual = 0;
        }
    }
}
