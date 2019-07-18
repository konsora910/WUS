using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    [SerializeField] public GameObject TenPlace;
    [SerializeField] public GameObject FirstPlace;
    [SerializeField] public Sprite[] Times;
    [SerializeField] public float FirstSeconds;
    [SerializeField] public int TenSeconds;
    Image TenSprite;
    Image FirstSprite;
    // Start is called before the first frame update
    void Start()
    {
        TenSprite = TenPlace.gameObject.GetComponent<Image>();
        FirstSprite = FirstPlace.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TenSeconds <= 0 && FirstSeconds <=0)
        {
            //ここにゲームオーバー処理
            SceneManager.LoadScene("TimeOver");
        }
        else
        {

            if (FirstSeconds < 0)
            {
                FirstSeconds = 9.9f;
                TenSeconds -= 1;
            }

            FirstSprite.sprite = Times[(int)FirstSeconds];
            TenSprite.sprite = Times[TenSeconds];
            FirstSeconds -= Time.deltaTime;
        }

    }
}
