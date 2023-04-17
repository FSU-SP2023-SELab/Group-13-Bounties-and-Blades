using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler 
{
    private void Awake(){
        // Empty
    }
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("Down");
    }

    public void OnPointerUp(PointerEventData eventData){
        Debug.Log("Up");
    }
    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("Click");
    }

    public void OnPointerEnter(PointerEventData eventData){
        // Empty
    }

    public void OnPointerExit(PointerEventData eventData){
        // Empty
    }

    public void test(){
        Debug.Log("Test");
    }
}
