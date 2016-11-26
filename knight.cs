using UnityEngine;
using System.Collections;


public class knight : MonoBehaviour {

	//Knight stats
	public int knightHp = 100;
	public int knightLevel = 5; 

	//Knight Moveset
	public int guardianStrikeDmg;

	//Other fighters
	public zombie zombie;
	public GameObject mage;

	//Combat Log
	public combatLog combatLog;
	public string log;

	public void guardianStrike(){
		guardianStrikeDmg = knightLevel * 5;
		zombie.zombieHp -= guardianStrikeDmg;

		log = ("Knight did " + guardianStrikeDmg + " damage to the zombie!");

		combatLog.UpdateCombatLog (log);

		mage.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
