using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class MaquinaDeEstados : MonoBehaviour
{

    Estado estadoActual;
    public NavMeshAgent agent;
    public List<Transform> posiciones = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        estadoActual = new EstadoPatrulla(agent, posiciones);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transicion transicion in estadoActual.transiciones)
        {
            if(transicion.condicion.Comprobar())
            {
                estadoActual = transicion.siguiendoEstado;
            }
        }
        estadoActual.HacerAccion();
    }
}
