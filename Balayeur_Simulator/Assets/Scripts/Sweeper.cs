using UnityEngine;
using System.Collections;

public class Sweeper : MonoBehaviour {


    //[SerializeField]
    private float m_fTranslation;

    [SerializeField]
    private float m_fSpeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        m_fTranslation = Input.GetAxis("Horizontal") * m_fSpeed;
        m_fTranslation *= Time.deltaTime;
        transform.Translate(m_fTranslation, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("flower"))
        {
            Physics2D.IgnoreCollision(c.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}
