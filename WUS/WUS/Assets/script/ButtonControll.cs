using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonControll : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private RectTransform RectTra;
    public float RangeX = 0;
    public float RangeY = 0;
    private void Start()
    {
        RectTra = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        float St = 1.2f;
        RectTra.sizeDelta = new Vector2(RangeX * St, RangeY * St);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        RectTra.sizeDelta = new Vector2(RangeX, RangeY);
    }
}
