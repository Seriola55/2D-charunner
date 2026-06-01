using UnityEngine;

public class BreakWall : MonoBehaviour
{
    public float breakSpeed = 20f;   //条件スピード
    public float breakDe = 0.9f;    //破壊時の減速
   

    void OnCollisionEnter2D(Collision2D collision)
    {
        CheckBreak(collision);   //触れた時
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        CheckBreak(collision);   //触れている最中
    }


    void CheckBreak(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player =collision.gameObject.GetComponent<PlayerController>();
            if(player != null && player.speed > breakSpeed)
            {
                player.speed*= breakDe;
                Destroy(gameObject);      //オブジェクト破壊
            }
          
        }
    }
}
