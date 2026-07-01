using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public float breakSpeed = 20f;   //条件スピード
    public float breakDe = 0.9f;    //破壊時の減速

    public AudioManager audioManager;

    public GameObject breakEffect;
    public GameObject touchEffect;
    public float touchInterval =0.2f;
    float touchTimer=0.2f;
   
    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckBreak(collision);   //触れた時
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        CheckBreak(collision);   //触れている最中
        if(collision.gameObject.CompareTag("Player"))
       {
            touchTimer += Time.deltaTime;

            if(touchTimer >= touchInterval)
            {
            if(touchEffect != null)   //壁に触れている最中のエフェクト
                {
                    Instantiate(touchEffect, transform.position, Quaternion.identity);
                }
                touchTimer = 0f;
            }
        }
    }


    void CheckBreak(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player =collision.gameObject.GetComponent<PlayerController>();
            if(player != null && player.speed > breakSpeed)
            {
                if(audioManager != null)
                {
                    audioManager.PlayBreakWall();
                }

                if(breakEffect != null)
                {
                    Instantiate(breakEffect,transform.position,Quaternion.identity);
                }
                
                player.speed*= breakDe;
                Destroy(gameObject);      //オブジェクト破壊
            }
          
        }
    }
}
