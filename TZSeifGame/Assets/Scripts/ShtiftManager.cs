using UnityEngine;
using UnityEngine.UI;

public class ShtiftManager : MonoBehaviour
{
    public int id;
    [Range(0, 6)]
    public int shtiftPos;
    [HideInInspector] public int shtiftPosClone;
    [Range(0, 6)]
    public int truePos;
    private Image image;
    [HideInInspector] public Vector3 vectorTrue;
    [HideInInspector] public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        SetPosition();
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

    // Update is called once per frame
    void Update()
    {
        if (InteractController.resetPos)
            SetPosition();      
    }

    private void SetPosition()
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

}
