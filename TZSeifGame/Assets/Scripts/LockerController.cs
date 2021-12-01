using UnityEngine;

public class LockerController : MonoBehaviour
{
    private int shtif1;
    private int shtif2;
    private int shtif3;
    private int shtif4;
    private int shtif5;
    public static int resultTruePos;
    public static bool winIsActiv;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
    }

    private void Update()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 100);

        if (Input.GetMouseButtonDown(0) && hit)
        {
            if (hit.collider.gameObject.CompareTag("Shtift"))
            {
                ShtiftManager shtiftManager = hit.collider.gameObject.GetComponent<ShtiftManager>();
                shtiftManager.shtiftPosClone++;
                shtiftManager.animator.enabled = true;
                shtiftManager.animator.SetInteger("State", shtiftManager.shtiftPosClone);
                audioManager.AudioPlay(audioManager.switchShtift);
                if (shtiftManager.shtiftPosClone == 7)
                {
                    shtiftManager.animator.SetInteger("State", shtiftManager.shtiftPosClone);
                    audioManager.AudioPlay(audioManager.pruzhinaOtskok);
                    shtiftManager.shtiftPosClone = 0;
                }

                if (shtiftManager.shtiftPosClone == shtiftManager.truePos && shtiftManager.id == 1)
                {
                    shtif1++;
                    audioManager.AudioPlay(audioManager.unlockShtift);
                }
                else if(shtiftManager.id == 1) shtif1 = 0;
                if (shtiftManager.shtiftPosClone == shtiftManager.truePos && shtiftManager.id == 2)
                {
                    shtif2++;
                    audioManager.AudioPlay(audioManager.unlockShtift);
                }
                else if (shtiftManager.id == 2) shtif2 = 0;
                if (shtiftManager.shtiftPosClone == shtiftManager.truePos && shtiftManager.id == 3)
                {
                    shtif3++;
                    audioManager.AudioPlay(audioManager.unlockShtift);
                }
                else if (shtiftManager.id == 3) shtif3 = 0;
                if (shtiftManager.shtiftPosClone == shtiftManager.truePos && shtiftManager.id == 4)
                {
                    shtif4++;
                    audioManager.AudioPlay(audioManager.unlockShtift);
                }
                else if (shtiftManager.id == 4) shtif4 = 0;
                if (shtiftManager.shtiftPosClone == shtiftManager.truePos && shtiftManager.id == 5)
                {
                    shtif5++;
                    audioManager.AudioPlay(audioManager.unlockShtift);
                }
                else if (shtiftManager.id == 5) shtif5 = 0;
                resultTruePos = shtif1 + shtif2 + shtif3 + shtif4 + shtif5;
            }
        }
        if (resultTruePos == 5)
            winIsActiv = true;
    }

}
