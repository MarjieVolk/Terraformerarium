using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(HasOrganismTooltip))]
public class OrganismIconUI : MonoBehaviour
{
    private const int MaxOfType = 3;
    
    public EOrganism type;
    public EcosystemReference ecosystem;
    [SerializeField] private Text countText;

    public void Start()
    {
        Instantiate(OrganismMap.Obj.GetIconPrefab(this.type), this.transform).transform.SetAsFirstSibling();
        this.GetComponent<HasOrganismTooltip>().type = this.type;
        SceneState.StateUpdated += RefreshUI;
        this.RefreshUI();
    }

    public void ToggleNumber()
    {
        IEnumerable<Organism> capsuleOrganisms = ecosystem.Ecosystem.ContainedOrganisms.Where(org => org.Type == this.type);
        int currentCount = capsuleOrganisms.Count();

        if (currentCount == MaxOfType)
            ecosystem.Ecosystem.RemoveOrganisms(capsuleOrganisms);
        else
        {
            ecosystem.Ecosystem.AddOrganism(OrganismLibrary.GetOrganismFor(this.type));
            PipeAnimator.Obj.PlayAnimation();
        }

        SceneState.NotifyStateUpdated();
    }

    private void RefreshUI()
    {
        int currentCount = ecosystem.Ecosystem.ContainedOrganisms.Where(org => org.Type == this.type).Count();
        countText.text = "x" + currentCount;

        Organism o = OrganismLibrary.GetOrganismFor(this.type);
        bool validTemp = 
            ecosystem.Ecosystem.Temperature >= o.MinimumTemperature 
            && ecosystem.Ecosystem.Temperature <= o.MaximumTemperature;

        if (validTemp)
            countText.color = Color.black;
        else
            countText.color = Color.red;
    }

    protected void OnDestroy()
    {
        SceneState.StateUpdated -= RefreshUI;
    }
}
