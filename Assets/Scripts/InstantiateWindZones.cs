using UnityEngine;
using System.Collections;

public class InstantiateWindZones : MonoBehaviour
{
    [SerializeField]
    private int m_iMaxNumberOfWindZones;

    //[SerializeField]
    private int m_iCurrentNumberOfWindZones;

    [SerializeField]
    private GameObject m_goWindZone;

    // Use this for initialization
    void Start ()
    {
        GameObject _goWindZone;
        while (m_iCurrentNumberOfWindZones < m_iMaxNumberOfWindZones)
        {
            _goWindZone = Instantiate(m_goWindZone) as GameObject;
            ++m_iCurrentNumberOfWindZones;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
