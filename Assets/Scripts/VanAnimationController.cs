using UnityEngine;
using System.Collections;

public class VanAnimationController : MonoBehaviour
{

    public float minValueForSpawnRange = 40f;
    public float maxValueForSpawnRange = 60f;

    private float nextAnimationTime = 0f;
    public Animation animation;

    // Use this for initialization
    void Start ()
    {
        nextAnimationTime = Random.Range(minValueForSpawnRange,maxValueForSpawnRange);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(" time : " + Time.time + " / nextanimtime : " + nextAnimationTime);
	    
        if (Time.time > nextAnimationTime)
        {
            nextAnimationTime = Time.time + Random.Range(minValueForSpawnRange, maxValueForSpawnRange);
            animation.Play();
        }
	}
}
