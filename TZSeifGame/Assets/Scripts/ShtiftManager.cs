using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

public class ShtiftManager : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int id;
    [Header("Дефолтная позиция")]
    [Range(0, 6)]
    [SerializeField] private int shtiftPos;
    private int shtiftPosClone;
    [Header("Верная позиция")]
    [Range(0, 6)]
    [SerializeField] private int truePos;
    private Image image;
    private Vector3 vectorTrue;
    private Animator animator;
    private AudioManager audioManager;
    public static UnityEvent OnDetectEvent = new UnityEvent();  // Fire Event


    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        SetDefaultPosition();
        SetTruePosition();
    }

    void Update()
    {
        if (GameManager.defaultPositionActiv)
        {
            SetDefaultPosition();
            UnlockStats.Reset();
        }
        if(UnlockStats.resultTruePos == 5)
        {
            UnlockStats.resultTruePos = 0;
            StartCoroutine(FireEvent());
        }
    }

    private IEnumerator FireEvent()
    {
        yield return new WaitForSeconds(0.3f);
        OnDetectEvent.Invoke();
    }

    private void SetDefaultPosition()
    {
        animator.enabled = false;
        shtiftPosClone = shtiftPos;
        switch (shtiftPos)
        {
            case 0:
                transform.localPosition = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                image.fillAmount = 1f;
                break;
            case 1:
                transform.localPosition = new Vector3(transform.localPosition.x, 36.34f, transform.localPosition.z);
                image.fillAmount = 0.74f;
                break;
            case 2:
                transform.localPosition = new Vector3(transform.localPosition.x, 54f, transform.localPosition.z);
                image.fillAmount = 0.62f;
                break;
            case 3:
                transform.localPosition = new Vector3(transform.localPosition.x, 72f, transform.localPosition.z);
                image.fillAmount = 0.5f;
                break;
            case 4:
                transform.localPosition = new Vector3(transform.localPosition.x, 92f, transform.localPosition.z);
                image.fillAmount = 0.35f;
                break;
            case 5:
                transform.localPosition = new Vector3(transform.localPosition.x, 112f, transform.localPosition.z);
                image.fillAmount = 0.2f;
                break;
            case 6:
                transform.localPosition = new Vector3(transform.localPosition.x, 128f, transform.localPosition.z);
                image.fillAmount = 0.09f;
                break;
        }
    }

    private void SetTruePosition()
    {
        switch (truePos)
        {
            case 0:
                vectorTrue = new Vector3(transform.localPosition.x, 0f, transform.localPosition.z);
                break;
            case 1:
                vectorTrue = new Vector3(transform.localPosition.x, 36.34f, transform.localPosition.z);
                break;
            case 2:
                vectorTrue = new Vector3(transform.localPosition.x, 54f, transform.localPosition.z);
                break;
            case 3:
                vectorTrue = new Vector3(transform.localPosition.x, 72f, transform.localPosition.z);
                break;
            case 4:
                vectorTrue = new Vector3(transform.localPosition.x, 92f, transform.localPosition.z);
                break;
            case 5:
                vectorTrue = new Vector3(transform.localPosition.x, 112f, transform.localPosition.z);
                break;
            case 6:
                vectorTrue = new Vector3(transform.localPosition.x, 128f, transform.localPosition.z);
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        shtiftPosClone++;
        animator.enabled = true;
        animator.SetInteger("State", shtiftPosClone);
        audioManager.AudioPlay(audioManager.switchShtift);
        if (shtiftPosClone == 7)
        {
            animator.SetInteger("State", shtiftPosClone);
            audioManager.AudioPlay(audioManager.pruzhinaOtskok);
            shtiftPosClone = 0;
        }
        if (id == 1)
            UnlockShtift(out UnlockStats.shtif1, 1);
        if (id == 2)
            UnlockShtift(out UnlockStats.shtif2, 2);
        if (id == 3)
            UnlockShtift(out UnlockStats.shtif3, 3);
        if (id == 4)
            UnlockShtift(out UnlockStats.shtif4, 4);
        if (id == 5)
            UnlockShtift(out UnlockStats.shtif5, 5);
        UnlockStats.AllUnlock();
    }

    private void UnlockShtift(out int shtift, int id)
    {
        shtift = 0;
        if (shtiftPosClone == truePos && this.id == id)
        {
            shtift++;
            audioManager.AudioPlay(audioManager.unlockShtift);
        }
        else if(this.id == id) shtift = 0;
    }
}
