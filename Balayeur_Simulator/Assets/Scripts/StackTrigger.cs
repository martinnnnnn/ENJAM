using UnityEngine;
using System.Collections;

public class StackTrigger : MonoBehaviour {



    private StackBody father;
    private int currentFlowerCounter = 0;

    private Sprite sprite1;
    private Sprite sprite2;
    private Sprite sprite3;

    private bool isCleaning = false;
    private bool isCleaningBerzerk = false;
    private float nextActionTime = 0.0f;


    // Use this for initialization
    void Start()
    {
        father = this.transform.parent.gameObject.GetComponent<StackBody>();

        sprite1 = Resources.Load(father.img_tas1, typeof(Sprite)) as Sprite;
        sprite2 = Resources.Load(father.img_tas2, typeof(Sprite)) as Sprite;
        sprite3 = Resources.Load(father.img_tas3, typeof(Sprite)) as Sprite;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.GetComponent<Leaf>() != null)
        {
            Destroy(c.gameObject);
            currentFlowerCounter++;
            handleLevel();
        }
        if (c.gameObject.GetComponent<Sweeper>() != null)
        {
            isCleaning = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.GetComponent<Sweeper>() != null)
        {
            isCleaning = false;
        }
    }


    void Update ()
    {
        if (Time.time > nextActionTime)
        {
            

            if (isCleaning && isCleaningBerzerk)
            {
                nextActionTime += father.periodBerzerk;
                currentFlowerCounter--;
            }
            else if (isCleaning)
            {
                nextActionTime += father.periodNormal;
                currentFlowerCounter--;
            }
        }
    }
    

private void handleLevel()
    {
        if (currentFlowerCounter < father.level2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (currentFlowerCounter >= father.level2 && currentFlowerCounter < father.level3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
}
