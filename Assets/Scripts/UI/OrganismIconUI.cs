using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(HasOrganismTooltip))]
public class OrganismIconUI : MonoBehaviour
{
    private const int MaxOfType = 3;
    
    public EOrganism type;
    public EcosystemReference ecosystem;
    public Text countText;

    public void Start()
    {
        Instantiate(OrganismMap.Obj.GetIconPrefab(this.type), this.transform).transform.SetAsFirstSibling();
        this.GetComponent<HasOrganismTooltip>().type = this.type;
        this.GetComponent<Button>().onClick.AddListener(this.ToggleNumber);
        SceneState.StateUpdated += RefreshUI;
        this.RefreshUI();
    }

    private void ToggleNumber()
    {
        IEnumerable<Organism> capsuleOrganisms = ecosystem.Ecosystem.ContainedOrganisms.Where(org => org.Type == this.type);
        int currentCount = capsuleOrganisms.Count();

        if (currentCount == MaxOfType)
            ecosystem.Ecosystem.RemoveOrganisms(capsuleOrganisms);
        else
            ecosystem.Ecosystem.AddOrganism(OrganismLibrary.GetOrganismFor(this.type));

        SceneState.NotifyStateUpdated();
    }

    private void RefreshUI()
    {
        int currentCount = ecosystem.Ecosystem.ContainedOrganisms.Where(org => org.Type == this.type).Count();
        countText.text = "x" + currentCount;
    }
}
