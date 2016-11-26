using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class combatLog : MonoBehaviour {

	Text combatLogText;

	// Use this for initialization
	void Start () {
		combatLogText = GetComponent<Text>();
	}
	
	public void UpdateCombatLog(string log){
		combatLogText.text = log.ToString ();
	}
}
