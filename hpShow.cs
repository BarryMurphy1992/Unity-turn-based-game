using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hpShow : MonoBehaviour {
	Text hpLabel;
	public combatController combatController;

	void Start () {
		hpLabel = GetComponent<Text>();
	}

	void Update(){
		hpLabel.text = ("Knight HP: "+combatController.knightHp.ToString()+"\nMage HP: "+combatController.mageHp.ToString()+"\nZombie HP: "+combatController.zombieHp.ToString());
	}
}
