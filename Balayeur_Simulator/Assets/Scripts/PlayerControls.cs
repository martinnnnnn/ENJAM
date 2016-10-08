using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    //[SerializeField]
    private float m_fTranslation;

    [SerializeField]
    private float m_fSpeed;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_fTranslation = Input.GetAxis("Horizontal") * m_fSpeed;
        m_fTranslation *= Time.deltaTime;
        transform.Translate(m_fTranslation, 0f, 0f);
    }
}
