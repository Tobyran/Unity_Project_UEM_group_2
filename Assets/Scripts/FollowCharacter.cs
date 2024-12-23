using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCharacter : MonoBehaviour
{
    public Vector3 margen;
    public Transform objetivo;
    float actualX;
    public float sensitividad = 1, minAnguloVerticaI =0, maxAnguIoVerticaI =60;


    // Update is called once per frame
    void Update()
    {
        //transform.position = player.transform.position + margen;
        transform.localPosition = objetivo.transform.position + margen;
        transform.LookAt(objetivo.transform.position);

        actualX += Input.GetAxis("Mouse X") * sensitividad;
    }

    private void LateUpdate() { 
        Quaternion rotation = Quaternion.Euler(0, actualX, 0);
        transform.position = objetivo.position + rotation* margen;
        transform.LookAt(objetivo) ;
    }
}
