using UnityEngine;
using System.Collections;



public enum EventObject
{
    INSERVEMENT = 0,
    DEPLACEMENT_SLOW = 1,
    DEPLACEMENT_SPEED = 2,
    SWEEP_BOOST = 3,
};




public class WindowsObject : MonoBehaviour
{

    public Sprite sprite;
    

    [HideInInspector]
    public EventObject type;
    [HideInInspector]
    public float eventLenght;
    //[HideInInspector]
    //public float eventTime;
    [HideInInspector]
    public float slowingValue;
    [HideInInspector]
    public float speedingValue;


}
