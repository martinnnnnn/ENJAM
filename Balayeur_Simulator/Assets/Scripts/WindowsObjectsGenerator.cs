using UnityEngine;
using System.Collections;
using System.Collections.Generic;




public class WindowsObjectsGenerator : MonoBehaviour {



    public static GameObject objectPrefab;

    public List<GameObject> windowsPositions;


    public int minWaitTime = 5;
    public int maxWaitTime = 10;

    
    public float eventLenght;
    
    public float slowingValue;
    
    public float speedingValue;


    //[SerializeField]
    private Vector2 m_v2Position;

    
    private float timeTillNextSpawn = 0f;

    


    // Use this for initialization
    void Start()
    {

    }



    void Update()
    {
        // generer objet
        

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
    }
}
