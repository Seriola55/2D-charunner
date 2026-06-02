using UnityEngine;

public class obstaclemove : MonoBehaviour
{
    public enum Movetype
    {
        None,
        Straight,
        Wave,
        Trigger,
        Enermy
    }
    public Movetype moveType = Movetype.None;

    public float speed = 5f;   //横の速さ

    public float waveSpeed= 2f;   //waveの速さ
    public float height =5f;  //waveの高さ

    public Transform player;
    bool active = false;
    public float triggerDis= 10f;  //トリガーの距離
    
    public float breakspeed =20f;  //倒せる速度
    Vector3 startPos;
    Rigidbody2D rb;

    void Start()
    {
        rb =GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    void Update()
    {
        switch (moveType)   //スイッチ切り替え
        {
            case Movetype.None: break;
            case Movetype.Straight: 
                MoveStraight();
                break;
            case Movetype.Wave:
                MoveWave();
                break;
            case Movetype.Trigger:
                MoveTrigger();
                break;
            case Movetype.Enermy:
                MoveEnermy();
                break;    
        }
    }

    void MoveStraight()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;   //左に動くだけ
    }

    void MoveWave()  //上下
    {
        float y =Mathf.Sin(Time.time * waveSpeed)* height;   
        transform.position =new Vector3(
            transform.position.x,
            startPos.y+y,
            transform.position.z
        );
    }
    void MoveTrigger()      //近づくと動く
    {
        if(player == null) return;
        float distance = Vector2.Distance(transform.position,player.position);
        if(distance < triggerDis)
        {
           active = true;
        }
        if(active)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
    void MoveEnermy()
    {
        rb.linearVelocity = new Vector2(-speed,rb.linearVelocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
            if(moveType != Movetype.Enermy)return;
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                if(player !=null && player.speed > breakspeed)
                {
                    Destroy(gameObject);
                }
                else if (player != null)
                {
                    player.isGameOver=true;
                }
            }
        }
}
