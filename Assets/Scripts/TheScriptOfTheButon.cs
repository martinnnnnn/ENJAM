using UnityEngine;
using System.Collections;

public class TheScriptOfTheButon : MonoBehaviour {

	


    public void LoadMenu()
    {
        Application.LoadLevel("StartMenu");
    }


    public void LoadGame()
    {
        Application.LoadLevel("test_martin3");
    }

    public void LoadEn()
    {
        Application.LoadLevel("EndMenu");
    }

}
