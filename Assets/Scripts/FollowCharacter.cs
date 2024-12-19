using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public Vector3 margen;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + margen;
        transform.localPosition = player.transform.position + margen;
        transform.LookAt(player.transform.position);
    }
}
