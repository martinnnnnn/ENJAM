using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    //[SerializeField]
    //private float m_fTimeBeforeDestruction;

    [SerializeField]
    private float m_fLinearDragMinBound;

    [SerializeField]
    private float m_fLinearDragMaxBound;

    [HideInInspector]
    public bool isDead = false;

    // Use this for initialization
    void Start ()
    {
        GetComponent<Rigidbody2D>().drag = Random.Range(m_fLinearDragMinBound, m_fLinearDragMaxBound);
        //Destroy(gameObject, m_fTimeBeforeDestruction);
    }
}
