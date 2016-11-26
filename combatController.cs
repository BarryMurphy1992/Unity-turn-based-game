using UnityEngine;
using System.Collections;

public class combatController : MonoBehaviour {
	
	//Knight Stats
	public int knightHp = 100;
	private int knightLevel = 5; 

	//Knight Moveset
	private int guardianStrikeDmg;
	
	//Mage Stats
	public int mageHp = 60;
	private int mageLevel = 4; 

	//Mage Moveset
	public int fireballDmg;
	
	//Zombie Stats
	public int zombieHp = 200;
	private int zombieLevel = 7; 
	
	
	//Combat Log & UI
	public GameObject knightUI;
	public GameObject mageUI;
	public combatLog combatLog;
	public string log;

	//Mouse Stuff
	public GameObject selectedEnemy = null;
	
	//Turns
	public enum GameState
	{
		KnightTurn, magesTurn, zombieTurn, victory
	}
	
	public GameState state = GameState.KnightTurn;



	// Use this for initialization
	void Start () {
		state = GameState.KnightTurn;
	}
	
	// Update is called once per frame
	void Update () {



		switch (state){

			//~~~~~~~~Knight's Turn~~~~~~~~
		case GameState.KnightTurn:
			knightUI.SetActive(true);

			state = GameState.KnightTurn;

			break;

			//~~~~~~~~Mage's Turn~~~~~~~~
		case GameState.magesTurn:
			mageUI.SetActive(true);
			state = GameState.magesTurn;


			break;

			//~~~~~~~~Zombie's turn~~~~~~~~
		case GameState.zombieTurn:

			state = GameState.zombieTurn;
			knightHp -= zombieLevel * 2;

			log = ("Zombie did " + guardianStrikeDmg + " damage to the knight!");
			
			combatLog.UpdateCombatLog (log);
			knightUI.SetActive(true);
			state =GameState.KnightTurn;

			break;

		case GameState.victory:


			mageUI.SetActive(false);
			knightUI.SetActive(false);
			
			break;

		}
	
	}



	//Knight moves

	public void guardianStrike(){
		guardianStrikeDmg = knightLevel * 2;


		StartCoroutine(checkForInput());
		
		log = ("Knight did " + guardianStrikeDmg + " damage to the zombie!");
		
		combatLog.UpdateCombatLog (log);

		Debug.Log ("BEING CALLED");
		//knightUI.SetActive (false);
		//if (zombieHp > 0) {
		//	state = GameState.magesTurn;
		//} else {
		//	checkForVictory ();
		//}
	}



	//Mage moves

	public void fireball(){
		fireballDmg = mageLevel * 2;
		zombieHp -= fireballDmg;
		
		log = ("Mage did " + fireballDmg + " damage to the zombie!");
		
		combatLog.UpdateCombatLog (log);


		mageUI.SetActive(false);

		if (zombieHp > 0) {
			state = GameState.zombieTurn;		} 
		else {
			checkForVictory ();
		}

	}

	public void checkForVictory(){

		if (zombieHp <= 0) {

			log = ("YOU WIN!");

			combatLog.UpdateCombatLog (log);
			
			state = GameState.victory;


		}
	}

	IEnumerator waitForSeconds() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 2 Seconds");
	}


	IEnumerator checkForInput(){

		do
		{
			
			log = ("Select the enemy you would like to attack");		
			combatLog.UpdateCombatLog (log);
			
			
			if (Input.GetMouseButtonDown (0)) {
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit))
					if (hit.collider.gameObject.name == "Zombie")
						selectedEnemy = hit.collider.gameObject;
						Debug.Log ("You clicked on: " + hit.collider.gameObject.name);
						zombieHp -= guardianStrikeDmg;
						

			}
			
		

			yield return null;
		} while (selectedEnemy == null);
		selectedEnemy = null;
	}

}