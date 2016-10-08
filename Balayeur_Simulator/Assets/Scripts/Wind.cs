using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Wind : MonoBehaviour {


    public double offset = 0.1;
    public double freqOfChange;



    // To use:
    // 1. Create an empty game object
    // Add a Collider2D to the empty object. I used a standard Box Collider 2D, as a trigger, to create an isolated square that applies "wind"
    // 3. Add this WindComponent to the empty object, then adjust the Force (Vector2). You can adjust this in the editor or in the script, as it is a public property
    // Note: Only works on game objects that have the Rigid Body 2D and Collider 2D components

    // Directional force applied to objects that enter this object's Collider 2D boundaries
    private Vector2 m_v2RandomForce, m_v2RandomPosition;

    private double m_fRandomForceX, m_fRandomForceY;

    [SerializeField]
    private float m_fMinForceBound;

    [SerializeField]
    private float m_fMaxForceBound;

    //private float m_fRandomPosX, m_fRandomPosY;

    [HideInInspector]
    private float m_fGameWidth;

    void Start()
    {
        m_fGameWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        /*m_fRandomPosX = Random.Range(-m_fGameWidth, m_fGameWidth);
        m_fRandomPosY = Random.Range(-5f, 5f);
        m_v2RandomPosition = new Vector2(m_fRandomPosX, m_fRandomPosY);*/
        transform.position = m_v2RandomPosition;

        m_fMinForceBound = -1f;
        m_fMaxForceBound = 1f;
    }

    // Internal list that tracks objects that enter this object's "zone"
    private List<Collider2D> objects = new List<Collider2D>();

    // This function is called every fixed framerate frame
    void FixedUpdate()
    {
        m_fRandomForceX = NextValue(m_fRandomForceX);//Random.Range(m_fMinForceBound, m_fMaxForceBound);
        m_fRandomForceY = NextValue(m_fRandomForceY);//Random.Range(m_fMinForceBound, m_fMaxForceBound);

        /*Debug.Log("X : " + m_fRandomForceX);
        Debug.Log("X : " + m_fRandomForceY);*/

        m_v2RandomForce = new Vector2((float)m_fRandomForceX, (float)m_fRandomForceY);



        // For every object being tracked
        for (int i = 0; i < objects.Count; i++)
        {
            if(objects[i] != null)
            {
                // Get the rigid body for the object.
                Rigidbody2D body = objects[i].attachedRigidbody;

                // Apply the force
                body.AddForce(m_v2RandomForce);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        objects.Add(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        objects.Remove(other);
    }

    public double NextValue(double previous)
    {
        double newValue;
        double tempOffset;
        tempOffset = (previous < 0) ? -offset : offset;

        newValue = UnityEngine.Random.Range((float)(previous - tempOffset), (float)(previous - tempOffset));

        return newValue;
    }

    //public double NextGaussianDouble(double previous)
    //{
    //    double U, u, v, S;

    //    do
    //    {
    //        u = 2.0 * UnityEngine.Random.Range(m_fMinForceBound, m_fMaxForceBound) - 1.0;
    //        v = 2.0 * UnityEngine.Random.Range(m_fMinForceBound, m_fMaxForceBound) - 1.0;
    //        S = u * u + v * v;
    //    }
    //    while (S >= 1.0);

    //    double fac = Math.Sqrt(-2.0 * Math.Log(S) / S);
    //    return u * fac;
    //}
}
