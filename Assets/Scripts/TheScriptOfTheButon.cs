using UnityEngine;
using System.Collections;

public class TheScriptOfTheButon : MonoBehaviour {

	


    public void LoadMenu()
    {
        Application.LoadLevel("_StartMenu");
    }


    public void LoadGame()
    {
        Application.LoadLevel("_Game");
    }

    public void LoadEn()
    {
        Application.LoadLevel("_EndMenu");
    }

}
