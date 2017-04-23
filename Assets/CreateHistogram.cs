using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHistogram : MonoBehaviour {

    public int height;
    public GameObject bar;

    private GameObject[] bars;

    // Use this for initialization
    void Start () {
        int[] sizes = new int[] {8, 9, 5, 5, 7, 3 };

        int maxSize = 0;
        foreach (int size in sizes) {
            if (size > maxSize) {
                maxSize = size;
            }
        }

        bars = new GameObject[sizes.Length];
        float width = this.transform.GetComponent<RectTransform>().sizeDelta.x / bars.Length;
        float height = bar.transform.GetComponent<RectTransform>().rect.height;

        for (int index = 0; index < bars.Length; ++index) {
            bars[index] = Instantiate(bar, this.transform);
            RectTransform xform = bars[index].GetComponent<RectTransform>();
            xform.sizeDelta = new Vector2(width, height * (sizes[index] / (float)maxSize));
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
