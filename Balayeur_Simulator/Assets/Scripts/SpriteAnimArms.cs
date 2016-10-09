using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnimArms : MonoBehaviour
{
    [HideInInspector]
    public GameObject AnimatedGameObject;
    public AnimSpriteSet[] AnimationSets;
    private int Cur_SpriteID;
    [HideInInspector]
    public float SecsPerFrame = 0.05f;

    void Awake()
    {
        Cur_SpriteID = 0;
        if (!AnimatedGameObject)
        {
            AnimatedGameObject = this.gameObject;
        }

        PlayAnimation(0,0.05f);
    }
    

    public void PlayAnimation(int ID, float secPerFrame)
    {
        SecsPerFrame = secPerFrame;
        //Add as much ID as necessary. Each is a different animation.
        switch (ID)
        {
            default:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSpriteArms", ID);
                break;
        }


    }

    IEnumerator AnimateSpriteArms(int ID)
    {
        switch (ID)
        {
            default:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                SecsPerFrame = getFreq();
                StartCoroutine("AnimateSpriteArms", getNextId());
                break;


        }

    }

    private int getNextId()
    {
        if (Stack.isCleaningBerzerk)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                return 3;
            }
            return 2;
        }
        else
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                return 1;
            }
            return 0;
        }
    }


    private float getFreq ()
    {
        if (Stack.isCleaningBerzerk)
        {
            return 0.05f;
        }
        return 0.1f;
    }

}