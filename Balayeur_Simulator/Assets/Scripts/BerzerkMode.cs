using UnityEngine;
using System.Collections;

public class BerzerkMode : MonoBehaviour
{


    public float animSpeedNormal = 0.1f;
    public float animSpeedBerzerk = 0.5f;


    public int berzerkValue = 50;
    public int berzerkValueMax = 200;

    public SpriteAnimLegs spriteanim;




    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (berzerkValue < berzerkValueMax)
        {
            berzerkValue++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spriteanim.stopCoroutine();
            if (berzerkValue > 3)
            {
                berzerkValue -= 3;
                Stack.isCleaningBerzerk = true;
                //spriteanim.SecsPerFrame = animSpeedBerzerk;
                //spriteanim.PlayAnimation(animSpeedBerzerk);
            }
            else
            {
                Stack.isCleaningBerzerk = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Stack.isCleaningBerzerk = false;
            //spriteanim.SecsPerFrame = animSpeedNormal;
            //spriteanim.PlayAnimation(animSpeedNormal);
        }

    }
}
