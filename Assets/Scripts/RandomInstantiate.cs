using UnityEngine;
using System.Collections;

public class RandomInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject m_goFlower;

    /*SerializeField]
    private int m_iMaxLeavesCpt;

    [SerializeField]
    private int m_iCurrentLeavesCpt;*/

    //[SerializeField]
    //private GameObject[] m_goTabCurrentLeaves;

    //[SerializeField]
    private float m_fRandomFloat;

    //[SerializeField]
    private Vector2 m_v2Position;

    [Range(0.0f, 12.85901f)]
    private float m_fGameWidth;

    //[SerializeField]
    private float m_fNextActionTime;

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float m_fFrequence;

    [SerializeField]
    private float m_fTime;

    [SerializeField]
    private float m_fDeltaIncrementation;

    // Use this for initialization
    void Start()
    {
        /*GameObject _goLeaf;
        _goLeaf = Instantiate(m_goFlower, transform.position, transform.rotation) as GameObject;
        m_goTabCurrentLeaves = GameObject.FindGameObjectsWithTag("flower");*/

        //m_fPeriod = 0.1f;
        //m_iCurrentLeavesCpt = 0;
       // m_fFrequence = 1f;
        m_fNextActionTime = 0f;
        m_fGameWidth = Camera.main.orthographicSize * Screen.width / Screen.height;

        /*Debug.Log(m_fGameWidth*2f);
        Debug.Log(m_fGameWidth);*/

        // m_fDeltaIncrementation = 0.01f;
        InvokeRepeating("IncreaseFrequence", m_fTime, m_fTime);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_goTabCurrentLeaves.Length);

        m_fRandomFloat = Random.Range(-m_fGameWidth, m_fGameWidth);
        m_v2Position = new Vector2(m_fRandomFloat, this.transform.position.y);

        if (Time.time > m_fNextActionTime)
        {
            m_fNextActionTime += m_fFrequence;
            GameObject _goLeaf;
            _goLeaf = Instantiate(m_goFlower, m_v2Position, transform.rotation) as GameObject;
            //m_goTabCurrentLeaves = GameObject.FindGameObjectsWithTag("flower");
            //++m_iCurrentLeavesCpt;
        }
        /*while (m_iCurrentLeavesCpt <= m_iMaxLeavesCpt)
        {*/
        /*if (m_iCurrentLeavesCpt < /*m_iMaxLeavesCpt*/ /*m_goTabCurrentLeaves.Length)*/


        //}
    }

    void IncreaseFrequence()
    {
        if (m_fFrequence > 0f)
        {
            m_fFrequence -= m_fDeltaIncrementation;
        }
        else
        {
            m_fFrequence = 0f;
        }
    }
}
