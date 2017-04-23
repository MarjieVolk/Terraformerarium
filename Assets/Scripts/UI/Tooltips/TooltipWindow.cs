using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipWindow : MonoBehaviour {

    public static TooltipWindow Obj { get; private set; }

    [SerializeField] private GameObject defaultTooltip;

    private HasTooltip owner;
	
    protected void Awake()
    {
        Obj = this;
        Instantiate(defaultTooltip, this.transform);
    }

    public void SetTooltip(HasTooltip owner, GameObject content)
    {
        SetTooltip(content);
        this.owner = owner;
    }

    public void ClearTooltip(HasTooltip owner)
    {
        if (owner == this.owner)
        {
            SetTooltip(Instantiate(defaultTooltip));
            this.owner = null;
        }
    }

    private void SetTooltip(GameObject content)
    {
        Destroy(this.transform.GetChild(0).gameObject);
        content.transform.SetParent(this.transform, false);
    }
}
