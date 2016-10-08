﻿using UnityEngine;
using System.Collections;

public class Stack : MonoBehaviour
{

    public int level2 = 3;
    public int level3 = 5;

    public string img_tas1;
    public string img_tas2;
    public string img_tas3;


    public float periodNormal = 1.0f;
    public float periodBerzerk = 0.5f;


    [HideInInspector]
    public int currentFlowerCounter;

    private Sprite sprite1;
    private Sprite sprite2;
    private Sprite sprite3;

    private bool isCleaning = false;
    private bool isCleaningBerzerk = false;
    private float nextActionTime = 0.0f;


    public static void CreateStack(Vector2 position, int initialFlowerCounter)
    {
        GameObject gObject = Instantiate(Resources.Load("StackPrefab")) as GameObject;
        gObject.transform.position = position;
        gObject.GetComponent<Stack>().currentFlowerCounter = initialFlowerCounter;
    }

    void Start()
    {
        sprite1 = Resources.Load(img_tas1, typeof(Sprite)) as Sprite;
        sprite2 = Resources.Load(img_tas2, typeof(Sprite)) as Sprite;
        sprite3 = Resources.Load(img_tas3, typeof(Sprite)) as Sprite;
    }



    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.GetComponent<Flower>() != null)
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
            Debug.Log("mescouilles");
            isCleaning = false;
        }
    }


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            //Debug.Log("time : " + Time.time + " / next : " + nextActionTime + " / bool : " + isCleaning);

            if (isCleaning && isCleaningBerzerk)
            {
                nextActionTime += periodBerzerk;
                currentFlowerCounter--;
            }
            else if (isCleaning)
            {
                nextActionTime += periodNormal;
                Debug.Log("qsmldkfjqsdmlkfj");
                currentFlowerCounter--;
            }
        }

        if (currentFlowerCounter <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void handleLevel()
    {
        if (currentFlowerCounter < level2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (currentFlowerCounter >= level2 && currentFlowerCounter < level3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
}
