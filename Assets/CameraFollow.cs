using UnityEngine;

public class CameraFollow :MonoBehaviour
{
    public Transform target;
    public float smoothCa = 5f;

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(
            target.position.x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * smoothCa
        );

    }
}
