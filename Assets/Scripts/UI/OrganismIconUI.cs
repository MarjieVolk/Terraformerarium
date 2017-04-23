using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.WebServerSharedDeps;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class OrganismIconUI : MonoBehaviour
{
    private const int MaxOfType = 3;
    
    public EOrganism type;

    private Ecosystem capsule;
    private CanvasGroup iconPrefab;

    public void Start()
    {
        // TODO look this up?
        capsule = new Ecosystem(0, 0, 0);

        iconPrefab = OrganismMap.Obj.GetIconPrefab(this.type);
        this.GetComponent<Button>().onClick.AddListener(this.ToggleNumber);
        this.RefreshUI();
    }

    private void ToggleNumber()
    {
        int currentCount = capsule.ContainedOrganisms.RemoveWhere(org => org.Type == this.type);
        int newCount = (currentCount + 1) % (MaxOfType + 1);
        for (int i = 0; i < newCount; i++)
            capsule.ContainedOrganisms.Add(OrganismLibrary.GetOrganismFor(this.type));

        this.RefreshUI();
    }

    private void RefreshUI()
    {
        for (int i = 0; i < this.transform.childCount; i++)
            Destroy(this.transform.GetChild(i).gameObject);

        int currentCount = capsule.ContainedOrganisms.Where(org => org.Type == this.type).Count();
        if (currentCount == 0)
        {
            Instantiate(iconPrefab, this.transform).alpha = 0.5f;
        } else
        {
            for (int i = 0; i < currentCount; i++)
                Instantiate(iconPrefab, this.transform);
        }
    }
}
