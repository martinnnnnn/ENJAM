using UnityEngine;
using System.Collections;

public class IncrementBounds : MonoBehaviour {

    [SerializeField]
    private float m_fDeltaIncrementation;

    [SerializeField]
    private float m_fTime;

    public float m_fLinearDragMinBound;

    public float m_fLinearDragMaxBound;

    // Use this for initialization
    void Awake ()
    {
        m_fLinearDragMinBound = 5f;
        m_fLinearDragMaxBound = 15f;
        InvokeRepeating("IncreaseBounds", m_fTime, m_fTime);
	}
	
	// Update is called once per frame
	void Update () {

    }

    void IncreaseBounds()
    {
        if(m_fLinearDragMinBound < 0f)
        {
            m_fLinearDragMinBound = 0f;
        }
        else
        {
            m_fLinearDragMinBound -= m_fDeltaIncrementation;
        }

        if (m_fLinearDragMaxBound < 0f)
        {
            m_fLinearDragMaxBound = 0f;
        }
        else
        {
            m_fLinearDragMaxBound -= m_fDeltaIncrementation;
        }
    }
}
