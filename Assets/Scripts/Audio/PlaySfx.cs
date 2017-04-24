using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioPlayer))]
public class PlaySfx : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private AudioClip mouseEnter;
    [SerializeField] private AudioClip mouseExit;
    [SerializeField] private AudioClip mouseDown;
    [SerializeField] private AudioClip mouseUp;
    
    private AudioPlayer Player { get { return this.GetComponent<AudioPlayer>(); } }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.Player.PlayClip(mouseEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.Player.PlayClip(mouseExit);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            this.Player.PlayClip(mouseUp);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            this.Player.PlayClip(mouseDown);
    }
}
