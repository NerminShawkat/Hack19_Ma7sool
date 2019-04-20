using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFix : MonoBehaviour {

	void Start () {
        Text[] temps = GetComponentsInChildren<Text>();
        for (int i = 0; i < temps.Length; i++)
        {
            temps[i].text = ArabicSupport.ArabicFixer.Fix(temps[i].text);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
