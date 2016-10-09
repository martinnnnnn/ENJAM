using UnityEngine;
using System.Collections;

public class AnimationManagerLegs : MonoBehaviour
{

    public int totalNumberOfFlowersLevel1 = 30;
    public int totalNumberOfFlowersLevel2 = 60;
    public int totalNumberOfFlowersEnd = 60;

    private int stage = 0;

    // Use this for initialization
    void Start()
    {
        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            stack.changementCountFlowerCallBack += triggerFlowerCount;
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
            Application.LoadLevel("StartupMenu");
        }


        if (numberOfFlowers < totalNumberOfFlowersLevel1)
        {
            if (stage > 0)
            {
                GetComponent<Animator>().SetTrigger("previousStage");
                stage = 0;
            }
        }
        else if (numberOfFlowers < totalNumberOfFlowersLevel2)
        {
            if (stage == 2)
            {
                GetComponent<Animator>().SetTrigger("previousStage");
                stage = 1;
            }
            else if (stage == 0)
            {
                GetComponent<Animator>().SetTrigger("nextStage");
                stage = 1;
            }
        }
        else
        {
            if (stage < 2)
            {
                GetComponent<Animator>().SetBool("nextStage", true);
                stage = 2;
            }
        }

    }





    void Update()
    {
        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            stack.changementCountFlowerCallBack += triggerFlowerCount;
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
}

