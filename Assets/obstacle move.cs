using UnityEngine;

public class obstaclemove : MonoBehaviour
{
    public enum Movetype
    {
        None,
        Straight,
        Wave,
        Trigger
    }
    public Movetype moveType = Movetype.None;

    public float speed = 5f;

    public float waveSpeed= 2f;
    public float height =5f;

    public Transform player;
    bool active = false;
    public float triggerDis= 10f;
    
    Vector3 startPos;

    void Start()
    {
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

}
