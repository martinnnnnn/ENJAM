using UnityEngine;
using System.Collections;

public class StartupStack : MonoBehaviour
{

    public int level2 = 5;
    public int level3 = 15;
    
    public float periodNormal = 1.0f;
    public float periodBerzerk = 0.5f;

    public GameObject theButon;

    [HideInInspector]
    public int currentFlowerCounter = 10;

    public Sprite spriteMediumStack;
    public Sprite spriteSmallStack;

    private bool isCleaning = false;
    [HideInInspector]
    static public bool isCleaningBerzerk = false;
    private float nextActionTime = 0.0f;

    [SerializeField]
    private float m_fOffsetY;

    void Start()
    {
        handleLevel();
        theButon.transform.localScale = new Vector2(0.0f, 0.0f);
    }



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
        if (Time.timeSinceLevelLoad > nextActionTime)
        {
            if (isCleaning && isCleaningBerzerk)
            {
                nextActionTime = Time.timeSinceLevelLoad + periodBerzerk;
                theButon.gameObject.transform.localScale = new Vector3(
                    theButon.gameObject.transform.localScale.x + 0.1f,
                    theButon.gameObject.transform.localScale.y + 0.1f,
                    theButon.gameObject.transform.localScale.z + 0.1f);
                currentFlowerCounter--;
            }
            else if (isCleaning)
            {
                nextActionTime = Time.timeSinceLevelLoad + periodNormal;
                theButon.gameObject.transform.localScale = new Vector3(
                    theButon.gameObject.transform.localScale.x + 0.1f,
                    theButon.gameObject.transform.localScale.y + 0.1f,
                    theButon.gameObject.transform.localScale.z + 0.1f);
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
            gameObject.transform.position = new Vector3(transform.position.x, m_fOffsetY, transform.position.z);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteMediumStack;
            gameObject.transform.position = new Vector3(transform.position.x, m_fOffsetY, transform.position.z);
        }
    }
}
