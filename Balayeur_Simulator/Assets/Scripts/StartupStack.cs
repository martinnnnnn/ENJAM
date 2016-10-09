using UnityEngine;
using System.Collections;

public class StartupStack : MonoBehaviour
{

    public int level2 = 5;
    public int level3 = 15;
    
    public float periodNormal = 1.0f;
    public float periodBerzerk = 0.5f;


    [HideInInspector]
    public int currentFlowerCounter = 10;

    public Sprite spriteMediumStack;
    public Sprite spriteSmallStack;

    private bool isCleaning = false;
    [HideInInspector]
    static public bool isCleaningBerzerk = false;
    private float nextActionTime = 0.0f;





    void OnTriggerEnter2D(Collider2D c)
    {
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
            }
            else if (isCleaning)
            {
                nextActionTime = Time.time + periodNormal;
                currentFlowerCounter--;
            }
            handleLevel();
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
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteSmallStack;
            gameObject.transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteSmallStack;
            gameObject.transform.position = new Vector3(transform.position.x, -2.8f, transform.position.z);
        }
    }
}
