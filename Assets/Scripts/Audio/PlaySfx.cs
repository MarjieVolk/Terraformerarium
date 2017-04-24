using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(AudioSource))]
public class PlaySfx : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private const float MinPitch = 0.9f;
    private const float MaxPitch = 1.1f;

    [SerializeField] private AudioClip mouseEnter;
    [SerializeField] private AudioClip mouseExit;
    [SerializeField] private AudioClip mouseDown;
    [SerializeField] private AudioClip mouseUp;
    private System.Random random;

    private AudioSource Player { get { return this.GetComponent<AudioSource>(); } }

    protected void Start()
    {
        this.random = new System.Random();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (mouseEnter != null)
            this.PlayClip(mouseEnter);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (mouseExit != null)
            this.PlayClip(mouseExit);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.mouseUp != null)
            this.PlayClip(mouseUp);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.mouseDown != null)
            this.PlayClip(mouseDown);
    }

    private void PlayClip(AudioClip clip)
    {
        this.Player.clip = clip;
        this.Player.pitch = (float)(random.NextDouble() * (MaxPitch - MinPitch)) + MinPitch;
        this.Player.Play();
    }
}
