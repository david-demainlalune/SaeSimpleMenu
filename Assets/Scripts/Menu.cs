using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public MenuButton[] buttons;
	
	private float axisSensitivity = 0.1f;
	
	private int selectedId = 0;
	
	private bool selectionChangeAllowed = true;
	
	// literal array; contains level name to be loaded on menu selection
	// this is not optimal. Loading levels or reacting to menu choices 
	// should not be the responsibility of the Menu
	// but for this example we shall close our eyes.
	private string[] levels = new string[] { "Play", "Instructions", "quit" };
	
	void Awake(){
		if (buttons.Length != levels.Length){
			Debug.LogError("there not as many buttons as levels to be loaded");
		}
	}
	
	// Use this for initialization
	void Start () {
		if (buttons.Length == 0){
			Debug.LogError("there no buttons defined");
			return;
		}
		
		buttons[selectedId].Select();
	}
	
	
	void Update(){
		float joyValue = Input.GetAxisRaw("Vertical");

		if (Mathf.Abs (joyValue) == 1 && selectionChangeAllowed){
			ChangeSelection(joyValue);
			selectionChangeAllowed = false;
		}
		
		if (joyValue == 0){
			selectionChangeAllowed = true;
		}
		
		
		if (Input.GetButtonDown("Fire1")){
			LoadLevel();
		}
	}
	
	void ChangeSelection(float joyValue){
		if (joyValue < axisSensitivity)
			MoveDown();
		else
			MoveUp();
	}
		
	void MoveUp(){
		buttons[selectedId].UnSelect();
		selectedId = selectedId - 1;
		
		if (selectedId < 0){
			selectedId = buttons.Length - 1;
		}
		buttons[selectedId].Select();
	}
	
	void MoveDown(){
		buttons[selectedId].UnSelect();
		selectedId = selectedId + 1;
		
		if (selectedId == buttons.Length){
			selectedId = 0;
		}
		buttons[selectedId].Select();
	}
	
	void LoadLevel(){
		string levelToLoad = levels[selectedId];
		Debug.Log("load level " + levelToLoad);
		if (levelToLoad == "quit"){
			Debug.Log("quitting, doesn't work in editor");
			Application.Quit();
		}
		Application.LoadLevel(levelToLoad);
	}
}
