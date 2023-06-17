using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAnimation : MonoBehaviour
{
    public RectTransform panel;
    public RectTransform finalPos;
    public float fadeTime;

    public void PanelDropIn() {
        panel.transform.localPosition = new Vector3(1000, 2000, 0);
        panel.DOAnchorPos(new Vector2(finalPos.localPosition.x, finalPos.localPosition.y), fadeTime, false);
    }
    public void PanelLeave() {
        panel.DOAnchorPos(new Vector2(1000, 2000), fadeTime, false);
    }
}
