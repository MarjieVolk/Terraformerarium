using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class HasTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public abstract GameObject TooltipContent { get; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipWindow.Obj.SetTooltip(this, TooltipContent);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipWindow.Obj.ClearTooltip(this);
    }

    public void OnDisable()
    {
        TooltipWindow.Obj.ClearTooltip(this);
    }

    public void OnDestroy()
    {
        TooltipWindow.Obj.ClearTooltip(this);
    }
}
