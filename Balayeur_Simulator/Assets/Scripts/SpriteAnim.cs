using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    public GameObject AnimatedGameObject;
    public AnimSpriteSet[] AnimationSets;
    private int Cur_SpriteID;
    private float SecsPerFrame = 0.25f;

    void Awake()
    {
        Cur_SpriteID = 0;
        if (!AnimatedGameObject)
        {
            AnimatedGameObject = this.gameObject;
        }
        PlayAnimation(2, 0.05f);
    }


    public void PlayAnimation(int ID, float secPerFrame)
    {
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
                StartCoroutine("AnimateSprite", returnNextId());
                break;
            case 1:
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
                StartCoroutine("AnimateSprite", nextID);
                break;
            case 2:                yield return new WaitForSeconds(SecsPerFrame);
                Debug.Log("start bug ID : " + ID + " / Cur_SpriteID : " + Cur_SpriteID);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = AnimationSets[ID].Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID >= AnimationSets[ID].Anim_Sprites.Length)
                {
                    Cur_SpriteID = 0;
                }
                Debug.Log("endbug");
                nextID = returnNextId();
                if (nextID != ID) Cur_SpriteID = 0;
                StartCoroutine("AnimateSprite", returnNextId());
                break;
        }

    }

    int returnNextId()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            return 1;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            return 0;
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