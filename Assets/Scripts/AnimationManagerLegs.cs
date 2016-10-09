using UnityEngine;
using System.Collections;

public class AnimationManagerLegs : MonoBehaviour
{

    public int totalNumberOfFlowersLevel1 = 30;
    public int totalNumberOfFlowersLevel2 = 60;
    public int totalNumberOfFlowersEnd = 60;


    public static int currentNumberOfFlower;

    private int stage = 0;

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
            Application.LoadLevel("_EndMenu");
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
}

