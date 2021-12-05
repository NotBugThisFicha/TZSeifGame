
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class BackGroundTouch : MonoBehaviour, IPointerDownHandler
{
    public static UnityEvent OnDetectEvent = new UnityEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        if(InteractSeif.closeWindIsActiv)
        {
            InteractSeif.closeWindIsActiv = false;
            FireEvent();
        }
    }

    private void FireEvent() => OnDetectEvent.Invoke();
}
