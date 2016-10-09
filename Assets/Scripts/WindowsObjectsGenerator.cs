using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class WindowsObjectsGenerator : MonoBehaviour
{
    public GameObject objectPrefab;

    public List<GameObject> windowsPositions;


    public int minWaitTime = 5;
    public int maxWaitTime = 10;

    
    public float eventLenght;
    
    public float slowingValue;
    
    public float speedingValue;
    public float fallingSpeed = 2;
    public static float berzerkBonus = 30;

    public string img_inversement;
    public string img_slow;
    public string img_speed;
    public string img_sweep;
    private Sprite sprite_inversement;
    private Sprite sprite_slow;
    private Sprite sprite_speed;
    private Sprite sprite_sweep;

    public string perso1;
    public string perso2;
    public string perso3;
    public string perso4;
    private Sprite sprite_perso1;
    private Sprite sprite_perso2;
    private Sprite sprite_perso3;
    private Sprite sprite_perso4;



    //[SerializeField]
    private Vector2 m_v2Position;


    private float timeTillNextSpawn = 0f;


    // Use this for initialization
    void Start()
    {
        sprite_inversement = Resources.Load(img_inversement, typeof(Sprite)) as Sprite;
        sprite_slow = Resources.Load(img_slow, typeof(Sprite)) as Sprite;
        sprite_speed = Resources.Load(img_speed, typeof(Sprite)) as Sprite;
        sprite_sweep = Resources.Load(img_sweep, typeof(Sprite)) as Sprite;

        sprite_perso1 = Resources.Load(perso1, typeof(Sprite)) as Sprite;
        sprite_perso2 = Resources.Load(perso2, typeof(Sprite)) as Sprite;
        sprite_perso3 = Resources.Load(perso3, typeof(Sprite)) as Sprite;
        sprite_perso4 = Resources.Load(perso4, typeof(Sprite)) as Sprite;
    }



    void Update()
    {
        if (Time.time > timeTillNextSpawn)
        {
            int spawningPosition = Random.Range( 0, windowsPositions.Count );
            timeTillNextSpawn += Random.Range(minWaitTime, maxWaitTime);
            EventObject eventType = (EventObject)Random.Range(0, System.Enum.GetNames(typeof(EventObject)).Length - 1);


            StartCoroutine(windowObjectSpawing(windowsPositions[spawningPosition].transform.position, eventType));
        }
    }


    IEnumerator windowObjectSpawing(Vector3 position, EventObject type)
    {
        
        GameObject g = new GameObject();
        g.AddComponent<SpriteRenderer>();
        int persoNumber = Random.Range(0, 3);
        switch (persoNumber)
        {
            case 0:
                g.GetComponent<SpriteRenderer>().sprite = sprite_perso1;
                break;
            case 1:
                g.GetComponent<SpriteRenderer>().sprite = sprite_perso2;
                break;
            case 2:
                g.GetComponent<SpriteRenderer>().sprite = sprite_perso3;
                break;
            case 3:
                g.GetComponent<SpriteRenderer>().sprite = sprite_perso4;
                break;
        }

        g.transform.position = new Vector3(
            position.x,
            position.y - 1.6f,
            position.z);
        g.GetComponent<SpriteRenderer>().sortingOrder = -5;
        g.transform.DOMove(new Vector3(position.x,position.y-0.3f,position.z),1.5f).OnComplete(() =>
        {
            //Destroy(g);
            StartCoroutine(PeopleDisapearing(g));
            CreateWindowsObjects(position, type);
        });
        

        yield return 0;
    }


    IEnumerator PeopleDisapearing(GameObject g)
    {
        Vector3 position = g.transform.position;
        g.transform.DOMove(new Vector3(position.x, position.y - 1.6f, position.z), 1.5f).OnComplete(() =>
        {
            Destroy(g);
        });
        yield return 0;
    }



    public void CreateWindowsObjects(Vector2 position, EventObject type)
    {
        GameObject gObject = Instantiate(objectPrefab) as GameObject;
        gObject.transform.position = position;
        WindowsObject windowsObject = gObject.GetComponent<WindowsObject>();
        windowsObject.type = type;
        windowsObject.eventLenght = eventLenght;
        windowsObject.slowingValue = slowingValue;
        windowsObject.speedingValue = speedingValue;
        gObject.AddComponent<SpriteRenderer>();
        switch (type)
        {
            case EventObject.INSERVEMENT:
                gObject.GetComponent<SpriteRenderer>().sprite = sprite_inversement;
                break;
            case EventObject.DEPLACEMENT_SLOW:
                gObject.GetComponent<SpriteRenderer>().sprite = sprite_slow;
                break;
            case EventObject.DEPLACEMENT_SPEED:
                gObject.GetComponent<SpriteRenderer>().sprite = sprite_speed;
                break;
            case EventObject.SWEEP_BOOST:
                gObject.GetComponent<SpriteRenderer>().sprite = sprite_sweep;
                break;
        }
        gObject.AddComponent<PolygonCollider2D>();
        gObject.AddComponent<Rigidbody2D>();
        gObject.GetComponent<Rigidbody2D>().drag = fallingSpeed;
    }
}
