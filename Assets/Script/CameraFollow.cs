using UnityEngine;
using System.Collections;

public class CameraFollow :MonoBehaviour
{
    public Transform target;
    public float smoothCa = 5f;
    public float shift_x = 2f;

    Vector3 shakeOffset = Vector3.zero;  //カメラ振動

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(
            target.position.x + shift_x,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            Time.deltaTime * smoothCa
        ) + shakeOffset;   
    }

     public void Shake(float duration, float strength)
        {
            StartCoroutine(ShakeCoroutine(duration, strength));
        }

        IEnumerator ShakeCoroutine(float duration, float strength)
        {
            float timer = 0f;

            while(timer < duration)
            {
                float x = Random.Range(-strength, strength);
                float y = Random.Range(-strength, strength);

            shakeOffset = new Vector3(x, y, 0f);

            timer += Time.unscaledDeltaTime;
            yield return null;
            }       //カメラゆれ

            shakeOffset = Vector3.zero;
        }
}
