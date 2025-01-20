using UnityEngine;
using UnityEngine.AI;

public class MiAgente : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform objetivo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(objetivo.position);
    }
}
