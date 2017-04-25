using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrganismSlotType
{
    NORMAL, FLYING, TREE
}

public class LandscapeSlot : MonoBehaviour
{
    public OrganismSlotType Type { get { return this.type; } }
    [SerializeField] OrganismSlotType type;

    public void ClearContents()
    {
        foreach (Transform child in this.transform)
            Destroy(child.gameObject);
    }

    public void SetContents(GameObject contents)
    {
        Instantiate(contents, this.transform);
    }
}
