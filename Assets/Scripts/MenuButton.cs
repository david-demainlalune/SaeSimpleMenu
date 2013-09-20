using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public Texture2D unselectedTexture;
    public Texture2D selectedTexture;
	
	bool isSelected = false;
	
	public void Select(){
		isSelected = true;
	}
	
	public void UnSelect(){
		isSelected = false;
	}
	
    void Update () {
		if (isSelected){
			guiTexture.texture = selectedTexture;
		}else{
			guiTexture.texture = unselectedTexture;
		}

    }
}
