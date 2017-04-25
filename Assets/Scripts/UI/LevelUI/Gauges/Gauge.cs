using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
	public void SetHighlighted(int minIndex, int maxIndex)
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            if (i >= minIndex && i <= maxIndex)
                this.transform.GetChild(i).GetComponent<Image>().color = Color.white;
            else
                this.transform.GetChild(i).GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        }
    }
}
