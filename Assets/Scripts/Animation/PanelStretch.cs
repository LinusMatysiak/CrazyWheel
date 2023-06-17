using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelStretch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Dane
    public GameObject panel;
    public GameObject button;
    public float slideInTime;
    public float slideOutTime;
    private RectTransform rectTr;
    private RectTransform parentRectTr;
    private Button panelButton;

    private void Awake()
    {
        rectTr = panel.GetComponent<RectTransform>();
        parentRectTr = GetComponentInParent<RectTransform>();
        panelButton = gameObject.GetComponent<Button>();
    }

    private void Start()
    {
        rectTr.sizeDelta = new Vector2(rectTr.sizeDelta.x, parentRectTr.sizeDelta.y);
    }

    //Po najechaniu myszk¹ pojawaia animacje
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (!panelButton.interactable){ return; }
        rectTr.DOKill();
        panel.SetActive(true);
        rectTr.DOSizeDelta(new Vector2(parentRectTr.sizeDelta.x, parentRectTr.sizeDelta.y), slideInTime);
        rectTr.DOAnchorPos(new Vector2(parentRectTr.sizeDelta.x / 2, 0f), slideInTime);
    }

    //Przy odsuwaniu myszki chowa animacje
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        rectTr.DOAnchorPos(new Vector2(0f, 0f), slideOutTime);
        rectTr
        .DOSizeDelta(new Vector2(0f, rectTr.sizeDelta.y), slideOutTime)
        .OnComplete(() => {
             panel.SetActive(false);
         });
    }
}