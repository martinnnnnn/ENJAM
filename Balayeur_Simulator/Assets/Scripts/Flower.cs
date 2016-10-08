using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    //[SerializeField]
    //private float m_fTimeBeforeDestruction;

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

    [SerializeField]
    private float m_fDeltaIncrementation;

    [HideInInspector]
    public bool isDead = false;

    [SerializeField]
    private float m_fTime;

    // Use this for initialization
    void Start ()
    {
        m_iRandomDirection = Random.Range(0, 2);
        m_fRandomRotation = Random.Range(m_fMinRotationBound, m_fMaxRotationBound);
        int _iIndice = Random.Range(0, m_sTabSprites.Length);
        GetComponent<SpriteRenderer>().sprite = m_sTabSprites[_iIndice];

        //InvokeRepeating("IncreaseBounds", m_fTime, m_fTime);

        GameObject _goManager = GameObject.FindGameObjectWithTag("manager");
        IncrementBounds _ibScript = _goManager.GetComponent<IncrementBounds>();
        GetComponent<Rigidbody2D>().drag = Random.Range(_ibScript.m_fLinearDragMinBound, _ibScript.m_fLinearDragMaxBound);

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
