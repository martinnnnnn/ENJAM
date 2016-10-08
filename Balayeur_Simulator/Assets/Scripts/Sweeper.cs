using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Sweeper : MonoBehaviour
{



    private List<WindowsObject> eventList = new List<WindowsObject>();

    //[SerializeField]
    private float m_fTranslation;

    [SerializeField]
    private float m_fSpeed;


    private int direction = 1;

    // Update is called once per frame
    void Update()
    {
        foreach (WindowsObject o in eventList)
        {
        }

        for (int i = 0; i < eventList.Count; ++i)
        {
            if (eventList[i] == null)
            {
                eventList.RemoveAt(i);
            }
            if (Time.time > eventList[i].eventLenght)
            {
                endWindowsObjectEffect(eventList[i]);
                Destroy(eventList[i]);
                eventList.RemoveAt(i);
            }

        }



        m_fTranslation = Input.GetAxis("Horizontal") * m_fSpeed * direction;
        m_fTranslation *= Time.deltaTime;
        transform.Translate(m_fTranslation, 0f, 0f);
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("flower"))
        {
            Physics2D.IgnoreCollision(c.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

        if (c.gameObject.GetComponent<WindowsObject>() != null)
        {
            startWindowsObjectEffect(c.gameObject.GetComponent<WindowsObject>());
        }
    }


    private void startWindowsObjectEffect(WindowsObject o)
    {
        eventList.Add(o);
        o.eventLenght += Time.time;

        switch (o.type)
        {
            case EventObject.INSERVEMENT:
                direction = -1;
                break;
            case EventObject.DEPLACEMENT_SPEED:
                ++m_fSpeed;
                break;
            case EventObject.DEPLACEMENT_SLOW:
                ++m_fSpeed;
                break;
            case EventObject.SWEEP_BOOST:
                break;
        }
    }

    private void endWindowsObjectEffect(WindowsObject o)
    {

        switch (o.type)
        {
            case EventObject.INSERVEMENT:
                direction = 1;
                break;
            case EventObject.DEPLACEMENT_SPEED:
                --m_fSpeed;
                break;
            case EventObject.DEPLACEMENT_SLOW:
                ++m_fSpeed;
                break;
            case EventObject.SWEEP_BOOST:
                break;
        }
    }




}
