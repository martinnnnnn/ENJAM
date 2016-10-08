using UnityEngine;
using System.Collections;

public class StackBody : MonoBehaviour
{

    public string img_tas1;
    public string img_tas2;
    public string img_tas3;

    public int level2 = 3;
    public int level3 = 5;

    public float periodNormal = 1.0f;
    public float periodBerzerk = 0.5f;


    private int currentFlowerCounter = 0;
    

    public static void CreateStack(Vector2 position)
    {
        GameObject gObject = Instantiate(Resources.Load("StackPrefab")) as GameObject;
        gObject.transform.position = position;
    }
    
}
