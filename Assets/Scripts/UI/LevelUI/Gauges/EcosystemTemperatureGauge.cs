using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Gauge))]
public class EcosystemTemperatureGauge : MonoBehaviour {

    [SerializeField] private EcosystemReference ecosystem;

	// Use this for initialization
	void Start () {
        SceneState.StateUpdated += Refresh;
        Refresh();
	}

    private void Refresh()
    {
        int index = ecosystem.Ecosystem.Temperature;
        this.GetComponent<Gauge>().SetHighlighted(index, index);
    }
	
	protected void OnDestroy()
    {
        SceneState.StateUpdated -= Refresh;
    }
}
