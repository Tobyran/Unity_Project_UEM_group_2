using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;
    public BarraVida logicaBarraVidaJugador;
    public float damage = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerTransform = FindAnyObjectByType<LogicaPersonaje>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = playerTransform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            logicaBarraVidaJugador.vidaActual -= damage;
        }
    }
}
