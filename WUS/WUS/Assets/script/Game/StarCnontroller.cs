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
    Vector2 currentPos;

    public Slider shotGauge;
    float speed = 0f;
    float gaugeLength = 0f;
    private bool shotGaugeSet = false;

    public bool bUse = false;
    public bool bClick=false;
    //矢印
    public bool bDir = false;

    bool _enabled = false;
    Renderer _renderer;
    public float angle;

    GameObject StarSel;

    StarSelect StarSelScript;

    //矢印
    GameObject StarDir;
    public float fScaleX;
    public float fScaleY;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid = GetComponent<Rigidbody2D>();

        _renderer = GetComponent<Renderer>();

        StarSel = GameObject.Find("Star"); 
        StarSelScript = StarSel.GetComponent<StarSelect>();
        audioSource = GetComponent<AudioSource>();

        StarDir = GameObject.Find("StarDir");

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
            }
            

            if (bClick)
            {
                currentPos = Input.mousePosition;

                distance = Vector2.Distance(startPos, currentPos);
                if (distance> MaxDistance)
                {
                    distance = MaxDistance;
                }

                fScaleX = 1 + distance / MaxDistance;
                fScaleY = 1 + distance / MaxDistance;
                
                if (distance > MinDistance)
                {
                    bDir = true;
                    StarDir.transform.localScale = new Vector3(fScaleX, fScaleY, 1);
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

                    distance = Vector2.Distance(startPos, endPos);
                    if (distance > MaxDistance)
                    {
                        distance = MaxDistance;
                    }

                    if (distance > MinDistance)
                    {
                        this.rigid.AddForce(startDirection * distance * 2f);

                        this.rigid.constraints = RigidbodyConstraints2D.None;
                        this.bUse = true;
                         _enabled = true;
                        this.bClick = false;
                        bDir = false;
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
        }

    }

    void FixedUpdate()
    {
        this.rigid.velocity *= 0.995f;
    }

    void shotGaugeValue()
    {
        gaugeLength += 0.025f;
        if (gaugeLength > 1.025f)
        {
            gaugeLength = 0;
        }

        shotGauge.value = gaugeLength;
        speed = gaugeLength * 1000f + 500f;

    }

}

