using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class WindowsObjectsGenerator : MonoBehaviour {



    public GameObject objectPrefab;

    public List<GameObject> windowsPositions;


    public int minWaitTime = 5;
    public int maxWaitTime = 10;

    
    public float eventLenght;
    
    public float slowingValue;
    
    public float speedingValue;

    public string img_inversement;
    public string img_slow;
    public string img_speed;
    public string img_sweep;
    private Sprite sprite_inversement;
    private Sprite sprite_slow;
    private Sprite sprite_speed;
    private Sprite sprite_sweep;

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
    }



    void Update()
    {
        if (Time.time > timeTillNextSpawn)
        {
            int spawningPosition = Random.Range( 0, windowsPositions.Count - 1 );
            timeTillNextSpawn += Random.Range(minWaitTime, maxWaitTime);
            EventObject eventType = (EventObject)Random.Range(0, System.Enum.GetNames(typeof(EventObject)).Length - 1);


            CreateWindowsObjects(windowsPositions[spawningPosition].transform.position, eventType);
        }
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
    }
}
