using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationManagerLegs : MonoBehaviour
{

    public int totalNumberOfFlowersLevel1 = 30;
    public int totalNumberOfFlowersLevel2 = 60;
    public int totalNumberOfFlowersEnd = 10;



    public int currentNumberOfFlower;

    private int stage = 0;

    private bool alreadyDieded = false;

    private float suffocationDelay = 10f;
    private float suffociationNextTime = 0f;


    // Use this for initialization
    void Start()
    {
        currentNumberOfFlower = 0;
        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            if (!stack.isAlreadyTrigger)
            {
                stack.changementCountFlowerCallBack += triggerFlowerCount;
                stack.isAlreadyTrigger = true;
            }
        }
    }




    void triggerFlowerCount()
    {
        int numberOfFlowers = 0;

        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            numberOfFlowers += stack.currentFlowerCounter;
        }

        if (numberOfFlowers > totalNumberOfFlowersEnd)
        {
            if (!alreadyDieded)
            {
                alreadyDieded = false;
                SceneManager.LoadScene("_EndMenu");
                //StartCoroutine(LaunchDeath());
                //SoundManager.PlaySoundOnce("game_over");
            }
            
        }


        if (numberOfFlowers < totalNumberOfFlowersLevel1)
        {
            if (stage > 0)
            {
                GetComponent<Animator>().SetTrigger("previousStage");
                SoundManager.PlaySoundOnce("voix_reniflement_01");
                stage = 0;
            }
        }
        else if (numberOfFlowers < totalNumberOfFlowersLevel2)
        {
            if (stage == 2)
            {
                GetComponent<Animator>().SetTrigger("previousStage");
                SoundManager.PlaySoundOnce("voix_eternuement_01");
                stage = 1;
            }
            else if (stage == 0)
            {
                SoundManager.PlaySoundOnce("voix_eternuement_01");
                GetComponent<Animator>().SetTrigger("nextStage");
                stage = 1;
            }
            
        }
        else
        {
            if (stage < 2)
            {
                GetComponent<Animator>().SetTrigger("nextStage");
                if (Time.timeSinceLevelLoad > suffociationNextTime)
                {
                    SoundManager.PlaySoundOnce("voix_suffocation");
                    suffociationNextTime = Time.timeSinceLevelLoad + suffocationDelay;
                }
                stage = 2;
            }
        }
        
    }


    void Update()
    {
        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            if (!stack.isAlreadyTrigger)
            {
                stack.changementCountFlowerCallBack += triggerFlowerCount;
                stack.isAlreadyTrigger = true;
            }
        }



        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetComponent<Animator>().SetInteger("direction", -1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("direction", 1);
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            GetComponent<Animator>().SetInteger("direction", 0);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("direction", 0);
        }


    }

  
    //IEnumerator LaunchDeath()
    //{
    //    yield return new WaitForSeconds(9);
    //    SceneManager.LoadScene("_EndMenu");
    //    yield return 0;
    //}

}

