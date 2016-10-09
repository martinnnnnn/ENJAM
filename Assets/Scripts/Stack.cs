using UnityEngine;
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
    public bool isAlreadyTrigger = false;

    [HideInInspector]
    public int currentFlowerCounter;

    private Sprite sprite1;
    private Sprite sprite2;
    private Sprite sprite3;

    private bool isCleaning = false;
    [HideInInspector]
    static public bool isCleaningBerzerk = false;
    private float nextActionTime = 0.0f;

    public System.Action changementCountFlowerCallBack;

    public static void CreateStack(Vector2 position, int initialFlowerCounter)
    {
        GameObject gObject = Instantiate(Resources.Load("prefabs/StackPrefab")) as GameObject;
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
            if (changementCountFlowerCallBack != null)
            {
                changementCountFlowerCallBack();
            }
            
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


    void Update()
    {
        if (Time.time > nextActionTime)
        {
            if (isCleaning && isCleaningBerzerk)
            {
                nextActionTime = Time.time + periodBerzerk;
                currentFlowerCounter--;
                if (changementCountFlowerCallBack != null)
                {
                    changementCountFlowerCallBack();
                }
            }
            else if (isCleaning)
            {
                nextActionTime = Time.time + periodNormal;
                currentFlowerCounter--;
                if (changementCountFlowerCallBack != null)
                {
                    changementCountFlowerCallBack();
                }
            }
            handleLevel();
        }
        
        if (currentFlowerCounter <= 0)
        {
            SoundManager.PlaySoundOnce("balais_01");
            Destroy(gameObject);
        }
    }


    private void handleLevel()
    {
        if (currentFlowerCounter < level2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite1;
            gameObject.transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
        }
        else if (currentFlowerCounter >= level2 && currentFlowerCounter < level3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite2;
            gameObject.transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprite3;
            gameObject.transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
        }
    }
}
