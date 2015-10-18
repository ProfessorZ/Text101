using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text gametext;
	private enum States { 
				cell,
				mirror,
				sheets_0,
				lock_0,
				cell_mirror,
				sheets_1,
				lock_1,
				corridor_0,
				stairs_0,
				floor,
				closet_door,
				corridor_1,
				stairs_1,
				in_closet,
				corridor_2,
				stairs_2,
				courtyard,
				corridor_3
				};

	private States myState;

	// Use this for initialization
		void Start () {
		gametext.text = "You were stupid enough to get caught while dealing weed on the street. " +
			"As a result, you were thrown in prison, in a " + 
				"3x2 cell with nothing in it. Since you left " + 
				"your bag of weed in the thrashcan of the corner you " +
				"usually deal at, you need to secure it.  " +
				"Just because it's some of the rarest weed known " +
				" to mankind.  But in order to do that... " + 
				"you need to break out of prison - Wentworth Miller-style. \n";
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if 		(myState == States.cell)		{state_cell();}
		else if (myState == States.sheets_0) 	{state_sheets_0();} 
		else if (myState == States.sheets_1) 	{state_sheets_1();}
		else if (myState == States.lock_0) 		{state_lock_0();}
		else if (myState == States.lock_1)	 	{state_lock_1();}
		else if (myState == States.mirror) 		{state_mirror();}
		else if (myState == States.cell_mirror) {state_cell_mirror();}
		else if (myState == States.corridor_0) 	{state_corridor_0();}

		else if (myState == States.stairs_0) 	{state_stairs_0();}
		else if (myState == States.floor) 		{state_floor();}
		else if (myState == States.closet_door) {state_closet_door();}
		else if (myState == States.corridor_1) 	{state_corridor_1();}
		else if (myState == States.stairs_1)	{state_stairs_1();}
		else if (myState == States.in_closet) 	{state_in_closet();}
		else if (myState == States.corridor_2)	{state_corridor_2();}
		else if (myState == States.stairs_2) 	{state_stairs_2();}
		else if (myState == States.courtyard) 	{state_courtyard();}
		else if (myState == States.corridor_3) 	{state_corridor_3();}

	}

	void state_cell(){

		gametext.text = "You were stupid enough to get caught while dealing weed on the street. " +
			"As a result, you were thrown in prison, in a " + 
				"3x2 cell with nothing in it. Since you left " + 
				"your bag of weed in the thrashcan of the corner you " +
				"usually deal at, you need to secure it.  " +
				"Just because it's some of the rarest weed known " +
				" to mankind.  But in order to do that... " + 
				"you need to break out of prison - Wentworth Miller-style. \n"+
				"There are some dirty sheets on the bed, mirror on the wall, and the door is locked from the outside.\n\n" + 
				"Press S to look at the Sheets, M to look at the Mirror and L to look at the Lock";
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) {myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) {myState = States.lock_0;}

	}
	void state_sheets_0(){
		gametext.text = "You can't believe you sleep in these rags, someone should change them....\n\n" +
					"Press R to Return!";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	void state_mirror(){
		gametext.text = "The old mirror on the wall is kinda dirty... It seems to be loose.\n\n" +
			"Press T to Take the mirror, Press R to Return!";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
		else if(Input.GetKeyDown (KeyCode.T)) {myState = States.cell_mirror;}
	}
	void state_sheets_1(){
		gametext.text = "Looking at the sheets with the mirror does not make them look any better - on the contrary.\n\n" +
			"Press R to Return to roaming your cell.";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}
	void state_lock_0(){
		gametext.text = "It's one of those button locks but you do not know the combination. If only there was a way to see the greasy fingerprints on the other side of the lock...\n\n" +
			"Press R to Return!";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}	
	void state_cell_mirror(){
		gametext.text = "You roam your cell with the mirror, and you still want to escape.\n" +
			"The dirty sheets are still there on the bed, the wall has a brighter colour "+
					"where the mirror used to be and that fucking door is still locked!\n\n"+
				"Press S to look at sheets, or L to look at the Lock";
			if(Input.GetKeyDown(KeyCode.S)) {myState = States.sheets_1;}
			else if(Input.GetKeyDown (KeyCode.L)) {myState = States.lock_1;}
	}	
	void state_lock_1(){
			gametext.text = "You look at the button lock with the mirror\n\n" +
						"You slide the mirror through the bars and you can see the fingerprints on the buttons.  "+
						"You give it a shot by trying a random combination "+
						"containing the buttons with fingerprints on it and the lock magically springs open!\n\n"+
				"Press O to Open door or press R to Return to your lousy cell!";
			if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
		else if(Input.GetKeyDown(KeyCode.O)) {myState = States.corridor_0;}
	}
	void state_corridor_0(){
		gametext.text = "You are out of your cell and take a deep breath of that \"fresh\" air. Still stinks. \n\n You are now in a corridor."+
			"The corridor leads to a staircase on the left,which leads to the courtyard, and you can make out a closet door on the right." +
				"Looks like the floor of this corridor has not been swept for a while - there are lots of little things lingering around."+
				"\n\n Press S to go to the Staircase, press C to inspect the closet and press L to Look at the floor.";
		if 			(Input.GetKeyDown (KeyCode.S)) 	{myState = States.stairs_0;}
		else if 	(Input.GetKeyDown(KeyCode.C))	{myState=States.closet_door;}
		else if 	(Input.GetKeyDown(KeyCode.L))	{myState=States.floor;}
	}

	void state_stairs_0() {
		gametext.text = "This staircase leads to the courtyard. You can make out silhouettes through the milky glass. Better find some disguise..."+
						"\n\nPress R to return";
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
		}
	void state_floor(){
		gametext.text = "You look at the messy floor and you spot a hairclip. What it is doing there or how it got there remains a mystery but it's quite convenient indeed..."+
			"\n\nPress H to pick up the Hairclip or R to Return";
		if 			(Input.GetKeyDown 	(KeyCode.H)) 	{myState = States.corridor_1;}
		else if 	(Input.GetKeyDown	(KeyCode.R))	{myState = States.corridor_0;}
	}
	void state_closet_door(){
		gametext.text = "You walk up to the closet. Looks like the janitor's storage room. Might be something interesting inside - too bad the door's locked. \n\n" +
			"Press R to Return";
		if (Input.GetKeyDown(KeyCode.R)) {	myState = States.corridor_0;}
	}
	void state_corridor_1(){
		gametext.text = "You are still in the corridor, now armed with a hairpin. Won't do much damage to the guards, but it might prove useful otherwise." +
			"The staircase didn't move (this is still not Hogwarts, no matter how much you wish for it) and is still on the left and still leads to the courtyard, and to the right that closet door still looks like it might hold something of interest."+
				"\n\n Press S to go to the Stairs and C to go to the Closet";
		if (Input.GetKeyDown(KeyCode.S)) { myState = States.stairs_1; }
		else if(Input.GetKeyDown(KeyCode.C)) { myState = States.in_closet;}
	}
	void state_stairs_1(){
		gametext.text = "You climb back up the staircase - still people on the other side of the door... Can't risk it. \n\nPress R to Return to the corridor";
		if(Input.GetKeyDown (KeyCode.R)) { myState = States.corridor_1;}
		}
	void state_in_closet(){
		gametext.text = "You use the hairpin to pick the lock of the closet and you hide in there. You find a janitor uniform. The orange jumpsuit is a dead give-away to the guards, you think by yourself."+
			"\n\n Press R to return to the corridor, or D to Dress up as the janitor and then return to the corridor.";
		if (Input.GetKeyDown(KeyCode.R)) { myState = States.corridor_2; }
		else if(Input.GetKeyDown(KeyCode.D)) { myState = States.corridor_3; }
	}
	void state_corridor_2(){
		gametext.text = "You are back in the corridor. The closet is still unlocked and going up the staircase without means to go past the guards means you will get caught2"+
			"\n\n Press S to go up the staircase, or C to go back to the closet";
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_2;}
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.in_closet;}
	}
	void state_stairs_2(){
		gametext.text = "You run up the stairs, right into the face of a guard. Back to the cell with";
	}
	void state_corridor_3(){
		gametext.text = "you go back to the corridor, dressed as a janitor. \n\n Press U to get back in the orange jump suit, or S to go up the staircase and through the courtyard.";
		if (Input.GetKeyDown(KeyCode.U)) {myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {myState = States.courtyard;}
	}
	void state_courtyard(){
		gametext.text = "You've reached the courtyard! From here it's just a couple of walls to jump over and then freedom! \n\n Press P to Play again while the developer works on chapter 3 - the run to freedom";
		if(Input.GetKeyDown(KeyCode.P)) {Start();}
	}
}
		
