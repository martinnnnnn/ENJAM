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

    [SerializeField]
    private Sprite[] m_sTabSprites;

    [SerializeField]
    private float m_fMinRotationBound;

    [SerializeField]
    private float m_fMaxRotationBound;

    //[SerializeField]
    private float m_fRandomRotation;

    //[SerializeField]
    private int m_iRandomDirection;

    [HideInInspector]
    public bool isDead = false;

    // Use this for initialization
    void Start ()
    {
        m_iRandomDirection = Random.Range(0, 2);
        m_fRandomRotation = Random.Range(m_fMinRotationBound, m_fMaxRotationBound);
        int _iIndice = Random.Range(0, m_sTabSprites.Length);
        GetComponent<SpriteRenderer>().sprite = m_sTabSprites[_iIndice];
        GetComponent<Rigidbody2D>().drag = Random.Range(m_fLinearDragMinBound, m_fLinearDragMaxBound);
        //Destroy(gameObject, m_fTimeBeforeDestruction);
    }

    void Update()
    {
        switch (m_iRandomDirection)
        {
            case 0:
                transform.Rotate(Vector3.forward * Time.deltaTime * m_fRandomRotation);
                break;
            case 1:
                transform.Rotate(Vector3.back * Time.deltaTime * m_fRandomRotation);
                break;
        }
    }
}
