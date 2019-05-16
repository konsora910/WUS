using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCnontroller : MonoBehaviour
{
    private const float MaxMagnitude = 2f;
    private const float MaxDistance = 200f;
    private const float MinDistance = 35f;
    public Vector3 currentForce = Vector3.zero;
    public float distance;

    Rigidbody2D rigid;
    Vector2 startPos;
    //  private float speed;

    public Slider shotGauge;
    float speed = 0f;
    float gaugeLength = 0f;
    bool shotGaugeSet = false;

   
    public bool bUse = false;

    bool _enabled = false;
    Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        // this.rigid.useGravity = false;

        _renderer = GetComponent<Renderer>();


    }

    // Update is called once per frame
    void Update()
    {

        // マウスを押した地点の座標を記録
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
            shotGaugeSet = true;
        }

        if (bUse)
        {

            // マウスを離した地点の座標から、発射方向を計算
            if (Input.GetMouseButtonUp(0))
            {

                Vector2 endPos = Input.mousePosition;
                Vector2 startDirection = -1 * (endPos - startPos).normalized;
               

                /*
                this.currentForce = endPos - startPos;
                if (this.currentForce.magnitude > MaxMagnitude * MaxMagnitude)
                {
                    this.currentForce *= MaxMagnitude / this.currentForce.magnitude;
                }
                */
                distance= Vector2.Distance(startPos, endPos);
                if(distance> MaxDistance)
                {
                    distance = MaxDistance;
                }

                if (distance> MinDistance) {
                    //this.rigid.AddForce(startDirection * speed);
                    this.rigid.AddForce(startDirection * distance * 2f);

                    shotGaugeSet = false;
                    Debug.Log(speed);
                    // this.rigid.useGravity = true;
                    this.rigid.constraints = RigidbodyConstraints2D.None;
                    this.bUse = false;
                    //画面外で消す
                    // _enabled = true;
                }
                

            }

            // マウスが押されている間 ショットゲージを呼ぶ
            if (shotGaugeSet)
            {
                shotGaugeValue();
            }

            // テスト用：スペースキー押下で停止
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.rigid.velocity *= 0;
            }
        }
        else
        {
            gaugeLength = 0;
        }
        
        if (_enabled && !_renderer.isVisible)
        {
            this.gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }

    }

    void FixedUpdate()
    {
        this.rigid.velocity *= 0.995f;
    }

    // ショットゲージ関数
    void shotGaugeValue()
    {
       // Debug.Log("呼び出し確認");
        
            gaugeLength += 0.025f;
            //ゲージがMaxでゼロに戻る
            if (gaugeLength > 1.025f)
            {
                gaugeLength = 0;
            }

            //ゲージ長さをlengthに代入
            shotGauge.value = gaugeLength;
            // スピードをゲージ値から計算
            speed = gaugeLength * 1000f + 500f;
       
    }




}

