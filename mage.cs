using UnityEngine;
using System.Collections;

public class mage : MonoBehaviour {

	//Mage Stats
	public int mageHp = 50;
	public int mageLevel = 3;


	//Knight Moveset
	public int fireballDmg;
	
	//Other fighters
	public zombie zombie;

	//Combat Log
	public combatLog combatLog;
	public string log;
	
	public GameObject knight;
	
	public void fireball(){
		fireballDmg = mageLevel * 2;
		zombie.zombieHp -= fireballDmg;

		log = ("Mage did " + fireballDmg + " damage to the zombie!");
		
		combatLog.UpdateCombatLog (log);
		
		knight.SetActive(true);
		this.gameObject.SetActive(false);
	}
}
