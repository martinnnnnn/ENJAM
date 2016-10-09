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
        if (Time.timeSinceLevelLoad > nextAnimationTime)
        {
            nextAnimationTime = Time.timeSinceLevelLoad + Random.Range(minValueForSpawnRange, maxValueForSpawnRange);
            animation.Play();
        }
	}
}
