using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TheScriptOfTheButon : MonoBehaviour {

	


    public void LoadMenu()
    {
        SceneManager.LoadScene("_StartMenu");
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("_Game_1");
    }

    //public void LoadEnd()
    //{
    //    Application.LoadLevel("_EndMenu");
    //}

}
