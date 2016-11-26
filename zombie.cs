using UnityEngine;
using System.Collections;

public class zombie : MonoBehaviour {

	//Zombie stats
	public int zombieHp = 200;
	public int zombieLevel = 7;

	void OnMouseOver(){
		Debug.Log ("Object: " + this.gameObject.name);
	}
}
