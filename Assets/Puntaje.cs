using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public GameObject player;
    public TextMeshProUGUI textoPuntaje;

    public int puntajeMaximo, puntaje, bonificacion;
    public float contador, rangodeTiempo;
    private BarraVida barraVida;

    private void Start()
    {
        barraVida = player.GetComponent<BarraVida>();
        puntaje = 0;
    }



    // Update is called once per frame
    void Update()
    {
        contador += Time.deltaTime;

        if (barraVida.vidaActual > 0)
        {
            if (contador > rangodeTiempo)
            {
                puntaje += bonificacion;
                contador = 0;
            }
        }

        textoPuntaje.text = puntaje.ToString();
        
    }
}
