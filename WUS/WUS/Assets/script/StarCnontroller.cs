using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarCnontroller : MonoBehaviour
{
    private const float MaxMagnitude = 2f;
    private const float MaxDistance = 210f;
    private const float MinDistance = 35f;
    public Vector3 currentForce = Vector3.zero;
    public float distance;
    AudioSource audioSource;
    public AudioClip sound1;
    Rigidbody2D rigid;
    Vector2 startPos;
    //現在のマウスの位置
    Vector2 currentPos;

    //  private float speed;

    public Slider shotGauge;
    float speed = 0f;
    float gaugeLength = 0f;
    bool shotGaugeSet = false;


    public bool bUse = false;
    public bool bClick=false;
    //矢印
    public bool bDir = false;

    bool _enabled = false;
    Renderer _renderer;
    public float angle;


    GameObject StarSel;

    StarSelect StarSelScript;

    

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();
        // this.rigid.useGravity = false;

        _renderer = GetComponent<Renderer>();

        StarSel = GameObject.Find("Star"); 
        StarSelScript = StarSel.GetComponent<StarSelect>();
        audioSource = GetComponent<AudioSource>();

        bDir = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (bUse)
        {
            bDir = false;
        }
        

        

        if (!bUse)
        {
            // マウスを押した地点の座標を記録
            if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
            shotGaugeSet = true;
              //  Debug.Log(this.startPos);
            }
            

            if (bClick)
            {
                currentPos = Input.mousePosition;

                distance = Vector2.Distance(startPos, currentPos);
                if (distance > MinDistance)
                {
                    bDir = true;
                }
                else
                {
                    bDir = false;
                }

                Vector2 vec2 = new Vector2(currentPos.x - startPos.x,currentPos.y - startPos.y);

                float r = Mathf.Atan2(vec2.y, vec2.x);
                angle = Mathf.Floor(r * 360 / (2 * Mathf.PI));


                // マウスを離した地点の座標から、発射方向を計算
                if (Input.GetMouseButtonUp(0))
                {
                    

                    Vector2 endPos = Input.mousePosition;
                    Vector2 startDirection = -1 * (endPos - startPos).normalized;
                    audioSource.PlayOneShot(sound1);

                    /*
                    this.currentForce = endPos - startPos;
                    if (this.currentForce.magnitude > MaxMagnitude * MaxMagnitude)
                    {
                        this.currentForce *= MaxMagnitude / this.currentForce.magnitude;
                    }
                    */
                    distance = Vector2.Distance(startPos, endPos);
                    if (distance > MaxDistance)
                    {
                        distance = MaxDistance;
                    }

                    if (distance > MinDistance)
                    {
                        
                        
                        //this.rigid.AddForce(startDirection * speed);
                        this.rigid.AddForce(startDirection * distance * 2f);

                     //   shotGaugeSet = false;
                        Debug.Log(speed);
                        // this.rigid.useGravity = true;
                        this.rigid.constraints = RigidbodyConstraints2D.None;
                        this.bUse = true;
                        //画面外で消す
                         _enabled = true;
                        this.bClick = false;
                        bDir = false;
                        // startPos = new Vector2(0f,0f);
                        //endPos = new Vector2(0f, 0f);
                        distance = 0f;



                    }
                    else
                    {
                        this.bClick = false;
                    }
                    this.bClick = false;
                    StarSelScript.clicknull();

                }
            }
            else
            {
                bDir = false;
            }
            

            // マウスが押されている間 ショットゲージを呼ぶ
            if (shotGaugeSet)
            {
               // shotGaugeValue();
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

