using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganismLibraryPopulator : MonoBehaviour
{
    private static bool initialized = false;
      
	public void Awake()
    {
        if (!initialized)
        {
            initialized = true;
            OrganismDefinitions.Populate();
        }
	}
}
