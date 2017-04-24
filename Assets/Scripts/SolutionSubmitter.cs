using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SolutionSubmitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Submit(SceneState.NextLeaderboardLevel, SceneState.CurrentSolution.Serialize()));
	}

    IEnumerator Submit(string level, string solution)
    {
        // submit the solution, get a score
        Dictionary<string, string> formData = new Dictionary<string, string>();
        formData["LevelKey"] = level;
        formData["SolutionData"] = solution;

        UnityWebRequest solutionSubmitRequest = UnityWebRequest.Post("http://terraformerarium.azurewebsites.net/api/solution", formData);
        // get the histogram
        UnityWebRequest histogramGetRequest = new UnityWebRequest("http://terraformerarium.azurewebsites.net/api/solution/summary?levelKey=" + level);

        Debug.Log("Submitting requests.");
        AsyncOperation solutionSubmitOperation = solutionSubmitRequest.Send();
        AsyncOperation histogramGetOperation = histogramGetRequest.Send();

        yield return solutionSubmitOperation;
        Debug.Log("Got response for solution submit: " + solutionSubmitRequest.responseCode);
        yield return histogramGetOperation;
        Debug.Log("Got response for histogram get: " + histogramGetRequest.responseCode);

        // TODO instantiate component to create histogram
        Debug.Log(solutionSubmitRequest.downloadHandler.text);
        Debug.Log(histogramGetRequest.downloadHandler.text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
