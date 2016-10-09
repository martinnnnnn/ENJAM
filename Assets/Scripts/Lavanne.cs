using UnityEngine;
using System.Collections;

public class Lavanne : MonoBehaviour
{
    [SerializeField]
    private float m_fSpeed;

    private Vector3 m_v3StartPos;

	// Use this for initialization
	void Start ()
    {
        m_v3StartPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = m_v3StartPos + new Vector3(0f , Mathf.Sin(Time.time), 0.0f);
        transform.position = transform.position + new Vector3(-1f, 0f, 0.0f);
        //transform.position = m_v3StartPos + new Vector3(0f, Mathf.Sin(Time.time), 0.0f);
        //transform.Translate(-1f * m_fSpeed, Mathf.Sin(Time.time)*0.01f, 0f);// Vector3.left * Time.deltaTime * m_fSpeed);
    }
}
