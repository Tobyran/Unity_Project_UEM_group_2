using TMPro;
using UnityEngine;

public class GetPuntaje : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    void Start()
    {
        m_TextMeshProUGUI.text = PlayerPrefs.GetInt("PuntajeMaximo").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
