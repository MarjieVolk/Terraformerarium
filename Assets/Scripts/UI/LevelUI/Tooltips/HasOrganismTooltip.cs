using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class HasOrganismTooltip : HasTooltip
{
    public OrganismTooltip tooltipPrefab;
    public EOrganism type;

    public override GameObject TooltipContent
    {
        get
        {
            OrganismTooltip tooltip = Instantiate(tooltipPrefab);
            tooltip.SetOrganism(type);
            return tooltip.gameObject;
        }
    }
}
