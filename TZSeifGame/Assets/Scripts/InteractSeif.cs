using UnityEngine;
using UnityEngine.EventSystems;

public class InteractSeif : MonoBehaviour, IPointerDownHandler
{
    [Header("����� UI")]
    [SerializeField] private GameObject Locker;
    public static bool closeWindIsActiv;
    public void OnPointerDown(PointerEventData eventData)
    {
        closeWindIsActiv = true;
        Locker.SetActive(true);
        gameObject.SetActive(false);
    }
}
