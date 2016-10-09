using UnityEngine;
using System.Collections;

public class AnimationManagerBroom : MonoBehaviour
{
    
    
    void Update()
    {

        if (Stack.isCleaningBerzerk)
        {
            GetComponent<Animator>().SetBool("berzerk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("berzerk", false);
        }


        //// si isCleaningBerzerk
        //if (Input.GetAxis("Horizontal") < 0)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("left");
            GetComponent<Animator>().SetBool("left", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        //else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Animator>().SetBool("left", false);
        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            GetComponent<Animator>().SetBool("left", false);
        }

    }
}

