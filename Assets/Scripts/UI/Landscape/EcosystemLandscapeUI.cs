using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EcosystemLandscapeUI : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;
    private IEnumerable<LandscapeSlot> slots;

	// Use this for initialization
	void Start () {
        SceneState.StateUpdated += Refresh;
        slots = this.GetSlots();
    }

    private IEnumerable<LandscapeSlot> GetSlots()
    {
        foreach (Transform child in this.transform)
        {
            LandscapeSlot slot = child.GetComponent<LandscapeSlot>();
            if (slot != null)
                yield return slot;
        }
    }

    private void Refresh()
    {
        foreach (LandscapeSlot slot in slots)
            slot.ClearContents();

        var groups = ecosystem.Ecosystem.ContainedOrganisms.GroupBy(o => OrganismMap.Obj.GetSlotType(o.Type));
        foreach (IGrouping<OrganismSlotType, Organism> group in groups)
        {
            IEnumerable<LandscapeSlot> validSlots = this.slots.Where(slot => slot.Type == group.Key);
            IEnumerator<LandscapeSlot> slotEnumer = validSlots.GetEnumerator();
            IEnumerator<Organism> organismEnumer = group.GetEnumerator();
            while (slotEnumer.MoveNext() && organismEnumer.MoveNext())
            {
                slotEnumer.Current.SetContents(OrganismMap.Obj.GetPrefab(organismEnumer.Current.Type));
            }
        }
    }
}
