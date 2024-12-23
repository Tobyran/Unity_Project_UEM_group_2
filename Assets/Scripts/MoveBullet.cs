using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed, damage, maxLife, count;
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (count >= maxLife)
        {
            Destroy(gameObject);
        }
    }
}
