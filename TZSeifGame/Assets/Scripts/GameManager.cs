using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("������")]
    [Tooltip("������������� UI �����")]
    [SerializeField] private GameObject seifInteract;
    [Tooltip("�������� ����� UI")]
    [SerializeField] private GameObject panelLocker;
    [Tooltip("VFX �������")]
    [SerializeField] private GameObject CoinVFX;
    [Tooltip("VFX ���� ������!")]
    [SerializeField] private GameObject panelWinVFX;
    [Tooltip("������ VFX UI ���� ������")]
    [SerializeField] private GameObject panelWinSeifOpen;
    [Tooltip("������ UI ���� ������")]
    [SerializeField] private GameObject panelSeifOpen;
    private Animator LockerAnim;
    public static bool defaultPositionActiv;

    // Start is called before the first frame update
    void Start()
    {
        LockerAnim = panelLocker.GetComponent<Animator>();
        ShtiftManager.OnDetectEvent.AddListener(OnDetectWinEvent);
        BackGroundTouch.OnDetectEvent.AddListener(OnDetectCloseWindEvent);
    }

    private IEnumerator WinerCoroutine()
    {
        Debug.Log("Winer");
        seifInteract.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        panelLocker.SetActive(false);
        panelWinVFX.SetActive(true);
        AudioManager.Instance.AudioPlay(AudioManager.Instance.seifOpen);
        panelWinSeifOpen.SetActive(true);
        CoinVFX.SetActive(true);
        panelSeifOpen.SetActive(true);
        StopCoroutine(WinerCoroutine());
    }
    private void OnDetectWinEvent()
    {
        StartCoroutine(WinerCoroutine());
    }

    private void OnDetectCloseWindEvent()
    {
        StartCoroutine(HoldDeactiv());
    }

    private IEnumerator HoldDeactiv()
    {
        Debug.Log("Hold");
        LockerAnim.SetTrigger("CloseWindow");
        AudioManager.Instance.AudioPlay(AudioManager.Instance.DeactivLocker);
        defaultPositionActiv = true;
        yield return new WaitForSeconds(0.5f);
        panelLocker.gameObject.SetActive(false);
        defaultPositionActiv = false;
        seifInteract.SetActive(true);
        StopCoroutine(HoldDeactiv());
    }
}
