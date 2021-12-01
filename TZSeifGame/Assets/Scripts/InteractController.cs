using System.Collections;
using UnityEngine;

public class InteractController : MonoBehaviour
{
    [SerializeField] private GameObject panelLocker;
    private Animator LockerAnim;
    private LayerMask layer;
    private string[] layerMass;
    public static bool resetPos = true;
    private AudioSource audioCloseLock;

    // Start is called before the first frame update
    void Start()
    {
        layer = LayerMask.GetMask("Default");
        layerMass = new string[] { "Disable", "UI" };
        LockerAnim = panelLocker.GetComponent<Animator>();
        audioCloseLock = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        #region(PCversion controll)
        if (Input.GetMouseButton(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 100, layer);

            if (hit)
            {
                if (hit.collider.gameObject.CompareTag("Seif"))
                    StartCoroutine(HoldDeactiv(true, LayerMask.GetMask(layerMass)));
                else if (hit.collider.gameObject.layer != 5)
                {
                    StartCoroutine(HoldDeactiv(false, LayerMask.GetMask("Default")));
                }

            }
        }
        #endregion
        int i = 0;
        while(i < Input.touchCount)
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero, 100, layer);

            if (hit)
            {
                if (hit.collider.gameObject.CompareTag("Seif"))
                    StartCoroutine(HoldDeactiv(true, LayerMask.GetMask(layerMass)));
                else if (hit.collider.gameObject.layer != 5)
                {
                    StartCoroutine(HoldDeactiv(false, LayerMask.GetMask("Default")));
                }
            }
            ++i;
        }
        
    }

    private IEnumerator HoldDeactiv(bool activ, LayerMask layer1)
    {
        if (!activ)
        {
            LockerAnim.SetTrigger("CloseWindow");
            audioCloseLock.Play();
        }
        yield return new WaitForSeconds(0.5f);
        panelLocker.gameObject.SetActive(activ);
        yield return new WaitForSeconds(0.3f);
        resetPos = false;
        layer = layer1;
        if (!activ)
            resetPos = true;
        else resetPos = false;
        StopCoroutine(HoldDeactiv(activ, layer1));
    }
}
