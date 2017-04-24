using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SolutionSubmitter : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(!SceneState.CurrentSolution.IsLegal())
        { 
            Debug.Log("WARNING!  Solution was not legal!  Server will refuse to score this solution!");
        }
	    StartCoroutine(Submit(SceneState.NextLeaderboardLevel, SceneState.CurrentSolution.ToXml()));
    }

    IEnumerator Submit(string level, string solution)
    {
        // submit the solution, get a score
        Dictionary<string, string> formData = new Dictionary<string, string>();
        formData["LevelKey"] = level;
        formData["SolutionData"] = solution;

        //const string rootUrl = "http://terraformerarium.azurewebsites.net/";
        const string rootUrl = "http://localhost/Terraformerarium/";

        UnityWebRequest solutionSubmitRequest = UnityWebRequest.Post(rootUrl + "api/solution", formData);
        // get the histogram
        UnityWebRequest histogramGetRequest = new UnityWebRequest(rootUrl + "api/solution/summary?levelKey=" + level);
        histogramGetRequest.SetRequestHeader("Accept", "application/json");
        histogramGetRequest.downloadHandler = new DownloadHandlerBuffer();

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
