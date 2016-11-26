using UnityEngine;
using System.Collections;

public class onClick : MonoBehaviour {

	public GameObject mage;
	public combatLog combatLog;

	public void onClicked(string name){

		Debug.Log ("Clicked a button: "+name);

		//combatLog.SetActive(false);


		mage.SetActive(true);

		this.gameObject.SetActive(false);
	}



}
