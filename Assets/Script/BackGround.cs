using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Transform cameraTransform;
    public float backgroundWidth = 2000f;

    void Update()
    {
        if(transform.position.x + backgroundWidth < cameraTransform.position.x)
        {
            transform.position += Vector3.right * backgroundWidth *2f;
        }
    }
}
