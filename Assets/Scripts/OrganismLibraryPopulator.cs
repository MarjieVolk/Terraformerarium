using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismLibraryPopulator : MonoBehaviour
{    
	public void Awake()
    {
        OrganismDefinitions.Populate();
	}
}
