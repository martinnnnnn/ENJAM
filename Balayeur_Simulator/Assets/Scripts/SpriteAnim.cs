using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{

    public int totalNumberOfFlowersLevel1 = 20;
    public int totalNumberOfFlowersLevel2 = 50;

    public GameObject AnimatedGameObject;
    public AnimSpriteSet[] AnimationSets;
    private int Cur_SpriteID;
    [HideInInspector]
    public float SecsPerFrame = 0.25f;

    void Awake()
    {
        Cur_SpriteID = 0;
        if (!AnimatedGameObject)
        {
            AnimatedGameObject = this.gameObject;
        }

        PlayAnimation(2,0.05f);
    }

    public void stopCoroutine()
    {
        StopCoroutine("AnimateSprite");
    }

    public void PlayAnimation(int ID, float secPerFrame)
    {
        if (secPerFrame != SecsPerFrame)
        {
            StopCoroutine("AnimateSprite");
        }

        SecsPerFrame = secPerFrame;
        StopCoroutine("AnimateSprite");
        //Add as much ID as necessary. Each is a different animation.
        switch (ID)
        {
            default:
                Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", ID);
                break;
        }


    }

    IEnumerator AnimateSprite(int ID)
    {
        int nextID;
        switch (ID)
        {
            case 0:
                //Debug.Log(SecsPerFrame);
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                nextID = returnNextId();
                if (nextID != ID) Cur_SpriteID = 0;
                ID = nextID;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 1:
               // Debug.Log(SecsPerFrame);
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                nextID = returnNextId();
                if (nextID != ID) Cur_SpriteID = 0;
                ID = nextID;
                StartCoroutine("AnimateSprite", ID);
                break;
            case 2:
                //Debug.Log(SecsPerFrame);
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                nextID = returnNextId();
                if (nextID != ID) Cur_SpriteID = 0;
                ID = nextID;
                StartCoroutine("AnimateSprite", ID);
                break;
        }

    }

    int returnNextId()
    {

        int numberOfFlowers = 0;
        
        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            numberOfFlowers += stack.currentFlowerCounter;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            if (numberOfFlowers < totalNumberOfFlowersLevel1)
            {
                
                return 1;
            }
            else if (numberOfFlowers < totalNumberOfFlowersLevel2)
            {
                // return animation lvl 2
            }
            else
            {
                // return animation lvl 
            }

        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            if (numberOfFlowers < totalNumberOfFlowersLevel1)
            {
                return 0;
            }
            else if (numberOfFlowers < totalNumberOfFlowersLevel2)
            {
                // return animation lvl 2
            }
            else
            {
                // return animation lvl 
            }
        }
        if (numberOfFlowers < totalNumberOfFlowersLevel1)
        {
            return 2;
        }
        else if (numberOfFlowers < totalNumberOfFlowersLevel2)
        {
            // return animation lvl 2
        }
        else
        {
            // return animation lvl 
        }
        return 2;
    }
}

[Serializable]
public class AnimSpriteSet
{
    public string AnimationName;
    public Sprite[] Anim_Sprites;
}