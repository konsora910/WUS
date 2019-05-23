using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Number : MonoBehaviour
{
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Image image;
    GameObject player;
    int ResCheck;
    
    public GameObject pl;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (ResCheck != 2)
        {
            ResCheck = player.GetComponent<Respawn>().GetResPNum();
        }

       
        switch (ResCheck)
        {
            case 0:
                image.sprite = Sprite1;
                break;
            case 1:
                image.sprite = Sprite2;
                break;
            case 2:
                image.sprite = Sprite3;
                break;
            default:
                break;
        }

    }
}
