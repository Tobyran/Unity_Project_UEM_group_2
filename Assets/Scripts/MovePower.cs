using UnityEngine;

public class MovePower : MonoBehaviour
{
    private bool hit=false;
    public float speed, damage, count, maxLife;
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (!hit)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if(hit || count >= maxLife)
        {
            transform.Translate(Vector3.zero);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Bullet"))
        {
            print("Enemigo golpeado!");
            Destroy(other);
            hit = true;                
        }
        else if (!hit && !other.transform.CompareTag("Bullet") && !other.transform.CompareTag("Player"))
        {
            hit = true;
        }
    }
}
