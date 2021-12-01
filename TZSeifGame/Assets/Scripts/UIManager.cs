using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Панели")]
    [SerializeField] private GameObject seifInteract;
    [SerializeField] private GameObject panelLocker;
    [SerializeField] private GameObject panelWinVFX;
    [SerializeField] private GameObject panelWinSeifOpen;
    [SerializeField] private GameObject panelSeifOpen;
    [SerializeField] private GameObject CoinVFX;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(LockerController.winIsActiv)
            StartCoroutine(WinerCoroutine());
    }

    private IEnumerator WinerCoroutine()
    {
        seifInteract.SetActive(false);
        yield return new WaitForSeconds(0.3f);
        panelLocker.SetActive(false);
        panelWinVFX.SetActive(true);
        audioManager.AudioPlay(audioManager.seifOpen);
        panelWinSeifOpen.SetActive(true);
        CoinVFX.SetActive(true);
        panelSeifOpen.SetActive(true);
        LockerController.resultTruePos = 0;
        LockerController.winIsActiv = false;
        StopCoroutine(WinerCoroutine());
    }
}
