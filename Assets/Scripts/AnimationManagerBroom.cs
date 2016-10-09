using UnityEngine;
using System.Collections;

public class AnimationManagerBroom : MonoBehaviour
{

    private bool played = false;
    
    void Update()
    {

        if (Stack.isCleaningBerzerk)
        {
            if (!played)
            {
                SoundManager.PlaySoundOnce("voix_turbo_01");
                played = true;
            }
            GetComponent<Animator>().SetBool("berzerk", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("berzerk", false);
            played = false;
        }


        //// si isCleaningBerzerk
        //if (Input.GetAxis("Horizontal") < 0)
        if (Input.GetKeyDown(KeyCode.Q))
        {
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

