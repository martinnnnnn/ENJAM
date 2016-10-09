using UnityEngine;
using System.Collections;

public class FeedBacksCarac : MonoBehaviour
{
    private Vector3 m_v3InitialPos;
    private Color m_cTextColor;
    private float m_fDamages;
    private GameObject m_goPlayer;
    private Vector3 m_v3PlayerPos;

    /*[SerializeField]
    private float m_fSpeed;*/

    [SerializeField]
    private float m_fOffsetY;

    [SerializeField]
    private float m_fOffsetX;

    [Range(0.0f, 1.0f)]
    [SerializeField]
    private float m_fOffsetAlpha;

    void Awake()
    {
        m_v3InitialPos = transform.position;
        m_goPlayer = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(m_goPlayer);
        //m_cTextColor = GetComponent<TextMesh>().color;
    }

    /*public void DamagesSubis(float _fDamages)
    {
        m_fDamages = _fDamages;
    }*/

    public void DisplayDamages()
    {
        /*if (m_fDamages < 0)
        {
            m_cTextColor = Color.green;
            float dmg = (float)System.Math.Round(m_fDamages, 2);
            dmg = System.Math.Abs(dmg);
            GetComponent<TextMesh>().text = "+" + dmg.ToString();
        }
        else
        {
            if (m_fDamages > 0)
            {
                m_cTextColor = Color.red;
                float dmg = (float)System.Math.Round(m_fDamages, 2);
                dmg = System.Math.Abs(dmg);
                GetComponent<TextMesh>().text = "-" + dmg.ToString();
            }
            else
            {
                GetComponent<TextMesh>().text = "";
            }
        }
*/
        transform.position = m_v3InitialPos;
        StartCoroutine(TranslationUp());
    }

    IEnumerator TranslationUp()
    {
        float fCpt = 0.0f;
        while (transform.position.y < (m_v3InitialPos.y + 1.0f))
        {
            transform.position += new Vector3(0.0f, fCpt, 0.0f);
            //Color cColor = m_cTextColor;
            //cColor.a -= (fCpt * 8.0f);
            //GetComponent<TextMesh>().color = cColor;
            fCpt += 0.01f;
            yield return new WaitForSeconds(0.05f);
        }
    }



    void Update()
    {
        //DisplayDamages();


        m_v3PlayerPos = m_goPlayer.transform.position;

        m_v3PlayerPos.z = 0f;
        //m_v3PlayerPos.y = 0f;

        Debug.Log(m_v3PlayerPos);

        //transform.Translate(Vector3.up * Time.deltaTime /** m_fSpeed*/);
        transform.position = m_v3PlayerPos + new Vector3(m_fOffsetX, m_fOffsetY, 0f);
        GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, m_fOffsetAlpha); 
    }
}
