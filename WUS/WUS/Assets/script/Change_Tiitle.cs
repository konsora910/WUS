using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Change_Tiitle : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject image_object;   
    public Image image_component;     
    public Transform myTransform;     

    // Start is called before the first frame update
    void Start()
    {
        image_object = GameObject.Find("Image");
    
        image_component = image_object.GetComponent<Image>();
        myTransform = image_object.GetComponent<Transform>();

        image_component.color = Color.blue; 
        myTransform.localPosition = new Vector3(-100.0f, 100.0f,0.0f); 
        myTransform.localScale = new Vector3(1.1f, 1.1f, 1.1f);       
    }

    public void OnPointerClick(PointerEventData pointerData)
    {
        SceneManager.LoadScene("SampleScene");
    }
   public void OnPointerEnter(PointerEventData eventData)
    {
        image_component.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image_component.color = Color.blue;
    }
}

