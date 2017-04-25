using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(PlaySfx))]
public class AddOrganismButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector3 pressedOffest;
    private Transform contentParent;

    protected void Start()
    {
        this.GetComponent<Button>().enabled = false;
        this.contentParent = this.transform.GetChild(0);
    }

	public void SetDisplay(OrganismIconUI display)
    {
        this.GetComponent<Button>().enabled = display != null;
        this.GetComponent<PlaySfx>().enabled = display != null;
        this.GetComponent<Button>().onClick.RemoveAllListeners();
        for (int i = 0; i < this.contentParent.childCount; i++)
            Destroy(this.contentParent.GetChild(i).gameObject);

        if (display != null)
        {
            this.GetComponent<Button>().onClick.AddListener(display.ToggleNumber);
            display.transform.SetParent(this.contentParent, false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            contentParent.transform.position += pressedOffest;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            contentParent.transform.position -= pressedOffest;
    }
}
