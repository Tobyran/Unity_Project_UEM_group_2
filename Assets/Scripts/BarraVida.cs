using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    public int vidaMax;
    public float vidaActual;
    public Image vidaImage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaActual = vidaMax;
    }

    // Update is called once per frame
    void Update()
    {
        RevisarVida();

        if (vidaActual <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void RevisarVida()
    {
        vidaImage.fillAmount = vidaActual / vidaMax;
    }
}
