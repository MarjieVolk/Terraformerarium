using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SetTemperatureGaugeButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Button>().onClick.AddListener(SetGauge);
	}
	
	private void SetGauge()
    {
        SceneState.CurrentCapsule.InitialTemperature = this.transform.GetSiblingIndex();
        SceneState.NotifyStateUpdated();
    }
}
