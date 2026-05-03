using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool onGround ;
    public Transform groundcheck;
    public float groundcheckR=0.2f;
    public LayerMask groundLayer;    //地面判定


    public float jumpForce =10f;   //junmp上
    public float jumpDe = 0.5f;   //ジャンプ調整


    public float speed = 0f;    //fuctual speed
    public float maxspeed = 20f;   //maxspped
    public float ac = 0.01f;   //加速
    public float de = 0.98f;   //減速


    public float charge=0f;   //溜め
    public float maxCharge= 28f;   //溜め最大
    public float speedCharge= 18f;   //溜めの速さ
    public float boothtSpeed= 30f;  //ブースト時の最高速　
    public float boothtDe=0.99f;  //最高速時の減速

    public float edgeHeight = -0.5f;


    public bool isGameOver = false;   //ゲームオーバー

    public TMP_Text speedText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGameOver)
        {
            if(Keyboard.current.rKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(0);
            }
            return;   //ゲームオーバーならリターン
        }
        
        if(transform.position.y < edgeHeight)
        {
            isGameOver = true;    //落下時にゲームオーバー
        }


        if(Keyboard.current.spaceKey.isPressed)    //スペースキー押された時
        {
            speed=speed*de;
            if(speed<0.01f) speed=0f;
            charge+=speedCharge*Time.deltaTime;   //溜め計算
            charge=Mathf.Clamp(charge,0f,maxCharge);
        }
        
        if(Keyboard.current.spaceKey.wasReleasedThisFrame)   //離した時
        {
            float t= charge/maxCharge;
            speed += t*maxCharge;   //溜めをスピード変換
            charge=0f;
        }
        if(speed>maxspeed)
        {
            speed *= boothtDe;   //マックス超えた時の減速
            if(speed<maxspeed)
            {
                speed= maxspeed;   //マックスの速度
            }
        }
        
        if(!Keyboard.current.spaceKey.isPressed && charge==0f )
        {
            if(speed<maxspeed)speed+= ac;   //加速
        }

        speed= Mathf.Clamp(speed,0f,boothtSpeed);   //速度の最小値、最大値

        onGround = Physics2D.OverlapCircle(
            (Vector2)groundcheck.position,
            groundcheckR,
            groundLayer)!= null;    //地面判定


        if (Keyboard.current.upArrowKey.wasPressedThisFrame && onGround)  //ジャンプキー押してかつ地面にいた場合
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);   //ジャンプ
        }

        if(Keyboard.current.upArrowKey.wasReleasedThisFrame && rb.linearVelocity.y >0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * jumpDe);
        }

       
        speedText.text= (speed).ToString("F2");   //速度表示
    }

    void FixedUpdate()
    {
        if(isGameOver)
        {
            speed= 0f;
            charge= 0f;
            rb.linearVelocity =Vector2.zero;   //ゲームオーバー時に速度停止
            return;
        }
        float finalSpeed = speed;
        rb.linearVelocity = new Vector2( finalSpeed , rb.linearVelocity.y); 
    }
    void OnCollisionEnter2D(Collision2D teki)
    {
        if (teki.gameObject.CompareTag("obstacle"))
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
    
}
