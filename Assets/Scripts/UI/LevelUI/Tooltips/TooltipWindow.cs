using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioPlayer))]
public class TooltipWindow : MonoBehaviour {

    public static TooltipWindow Obj { get; private set; }

    [SerializeField] private AudioClip showSfx;
    [SerializeField] private AudioClip hideSfx;
    [SerializeField] private GameObject defaultTooltip;

    private HasTooltip owner;

    private AudioPlayer Player { get { return this.GetComponent<AudioPlayer>(); } }

    protected void Awake()
    {
        Obj = this;
    }

    protected void Start()
    {
        Instantiate(defaultTooltip, this.transform);
    }

    public void SetTooltip(HasTooltip owner, GameObject content)
    {
        SetTooltip(content);
        this.owner = owner;
        this.Player.PlayClip(showSfx);
    }

    public void ClearTooltip(HasTooltip owner)
    {
        if (owner == this.owner)
        {
            SetTooltip(Instantiate(defaultTooltip));
            this.owner = null;
            this.Player.PlayClip(hideSfx);
        }
    }

    private void SetTooltip(GameObject content)
    {
        for (int i = 0; i < this.transform.childCount; i++)
            Destroy(this.transform.GetChild(i).gameObject);
        content.transform.SetParent(this.transform, false);
    }
}
