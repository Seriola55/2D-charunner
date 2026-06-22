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
    public float direction = -1;  //方向転換

    public float waveSpeed= 2f;   //waveの速さ
    public float height =5f;  //waveの高さ
    public float waveOffset = 0f;   //waveの時間のずれ

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
        if (player == null)
        {
            GameObject p = GameObject.FindWithTag("Player");
            if(p != null)
            {
                player = p.transform;
            }
        }
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
        float y =Mathf.Sin(Time.time * waveSpeed+waveOffset)* height;   
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
            transform.position += Vector3.left * speed * Time.deltaTime;  //左に動くスピード
        }
    }
    void MoveEnermy()
    {
        rb.linearVelocity = new Vector2(speed*direction,rb.linearVelocity.y);  //敵のスピード
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
            if(moveType != Movetype.Enermy)return;
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                if(player !=null && player.isClear)return;  //クリア状態なら発動しない
                if(player !=null && player.speed > breakspeed)
                {
                    Destroy(gameObject);   //速度高いと倒せる
                }
                else if (player != null)
                {
                    player.isGameOver=true;   //速度普通だと倒せない
                }
                return;
            }
            
            if(collision.gameObject.CompareTag("Wall")    //壁
            || collision.gameObject.CompareTag("obstacle")   //obstacle
            || collision.gameObject.GetComponent<BreakWall>() != null     //壊れる壁
            || collision.gameObject.GetComponent<obstaclemove>() != null)     //enermy用
            {
                direction *= -1;   //方向転換
            }
            
        }
}
