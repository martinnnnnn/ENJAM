﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;







public class Sweeper : MonoBehaviour
{
    
    private List<WindowObjectStruct> eventList = new List<WindowObjectStruct>();

    //[SerializeField]
    private float m_fTranslation;

    [SerializeField]
    private float m_fSpeed;


    private int direction = 1;


   


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < eventList.Count; ++i)
        {
            if (Time.time > eventList[i].eventLenght)
            {
                endWindowsObjectEffect(eventList[i]);
               // Destroy(eventList[i]);
                eventList.RemoveAt(i);
            }

        }
        int axe = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            axe = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            axe = 1;
        }


        m_fTranslation += axe * m_fSpeed * direction;
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
           
            WindowsObject objOrigin = c.gameObject.GetComponent<WindowsObject>();
            WindowObjectStruct objCopy = new WindowObjectStruct();
            objCopy.type = objOrigin.type;
            objCopy.eventLenght = objOrigin.eventLenght;
            objCopy.slowingValue = objOrigin.slowingValue;
            objCopy.speedingValue = objOrigin.speedingValue;

            startWindowsObjectEffect(objCopy);
            Destroy(c.gameObject);
        }
    }


    private void startWindowsObjectEffect(WindowObjectStruct o)
    {
        o.eventLenght += Time.time;
        eventList.Add(o);

        switch (o.type)
        {
            case EventObject.INSERVEMENT:
                direction = -1;
                break;
            case EventObject.DEPLACEMENT_SPEED:
                m_fSpeed += o.speedingValue;
                break;
            case EventObject.DEPLACEMENT_SLOW:
                m_fSpeed -= o.slowingValue;
                break;
            case EventObject.SWEEP_BOOST:
                BerzerkMode.BonusSweep(WindowsObjectsGenerator.berzerkBonus);
                break;
        }
    }

    private void endWindowsObjectEffect(WindowObjectStruct o)
    {
        switch (o.type)
        {
            case EventObject.INSERVEMENT:
                direction = 1;
                break;
            case EventObject.DEPLACEMENT_SPEED:
                m_fSpeed -= o.speedingValue;
                break;
            case EventObject.DEPLACEMENT_SLOW:
                m_fSpeed += o.slowingValue;
                break;
            case EventObject.SWEEP_BOOST:
                break;
        }
    }

    




}
