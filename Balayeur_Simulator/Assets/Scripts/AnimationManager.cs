using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour
{

    public int totalNumberOfFlowersLevel1 = 30;
    public int totalNumberOfFlowersLevel2 = 60;

    public GameObject marche_left;
    public GameObject marche_right;


    public GameObject marche_koff_left;
    public GameObject marche_koff_right;

    public GameObject marche_pls_left;
    public GameObject marche_pls_right;

    public GameObject balaie_left;
    public GameObject balaie_right;

    public GameObject balaie_vener_left;
    public GameObject balaie_vener_right;

    public GameObject standing;
    public GameObject standing_koff;
    public GameObject standing_pls;


    // Use this for initialization
    void Start()
    {

    }


    //private void reset ()
    //{
    //    marche_left.SetActive(false);
    //    marche_right.SetActive(false);


    //    marche_koff_left.SetActive(false);
    //    marche_koff_right.SetActive(false);

    //    marche_pls_left.SetActive(false);
    //    marche_pls_right.SetActive(false);

    //    balaie_left.SetActive(false);
    //    balaie_right.SetActive(false);

    //    balaie_vener_left.SetActive(false);
    //    balaie_vener_right.SetActive(false);

    //    standing.SetActive(false);
    //    standing_koff.SetActive(false);
    //    standing_pls.SetActive(false);
    //}


    // Update is called once per frame
    void Update()
    {


        //GetComponent<Animator>().SetBool("left", true);



        //reset();


        int numberOfFlowers = 0;

        foreach (Stack stack in FindObjectsOfType<Stack>())
        {
            numberOfFlowers += stack.currentFlowerCounter;
        }

        //// si isCleaningBerzerk
        if (Input.GetAxis("Horizontal") < 0)
        {
            
            GetComponent<Animator>().SetBool("left", true);
            if (Stack.isCleaningBerzerk)
            {
                GetComponent<Animator>().SetBool("berzerk", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("berzerk", false);
            }

            //if (numberOfFlowers < totalNumberOfFlowersLevel1)
            //{

            //}
            //else if (numberOfFlowers < totalNumberOfFlowersLevel2)
            //{

            //}
            //else
            //{

            //}
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            GetComponent<Animator>().SetBool("left", false);
            if (Stack.isCleaningBerzerk)
            {
                GetComponent<Animator>().SetBool("berzerk", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("berzerk", false);
            }


            //if (numberOfFlowers < totalNumberOfFlowersLevel1)
            //{

            //}
            //else if (numberOfFlowers < totalNumberOfFlowersLevel2)
            //{

            //}
            //else
            //{

            //}
        }
        else
        {
            //if (Stack.isCleaningBerzerk)
            //{

            //}
            //else
            //{

            //}

            //if (numberOfFlowers < totalNumberOfFlowersLevel1)
            //{

            //}
            //else if (numberOfFlowers < totalNumberOfFlowersLevel2)
            //{

            //}
            //else
            //{

            //}
        }

    }
}

