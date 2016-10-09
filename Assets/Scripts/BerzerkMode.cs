using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BerzerkMode : MonoBehaviour
{

    [SerializeField]
    private GameObject m_goProgressBar;

    private Image m_iProgressBarImage;

    public float animSpeedNormal = 0.1f;
    public float animSpeedBerzerk = 0.5f;

    public float minValueForBerzerk = 50;
    private bool canBerzerk = false;

    static private float berzerkValue = 0f;
    static public float berzerkValueMax = 100f;

    [SerializeField]
    private float m_fDeltaIncrementation;

    [SerializeField]
    private float m_fDeltaDecrementation;


    // Use this for initialization
    void Awake()
    {
        m_iProgressBarImage = m_goProgressBar.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (berzerkValue < berzerkValueMax)
        {
            berzerkValue += m_fDeltaIncrementation;
            if (!canBerzerk)
            {
                if (berzerkValue < minValueForBerzerk)
                {
                    m_iProgressBarImage.fillAmount = berzerkValue / berzerkValueMax;
                    return;
                }
                else
                {
                    canBerzerk = true;
                }
            }
        }

       
        if (berzerkValue >= m_fDeltaDecrementation)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                berzerkValue -= m_fDeltaDecrementation;
                Stack.isCleaningBerzerk = true;
            }
            else
            {
                canBerzerk = false;
                Stack.isCleaningBerzerk = false;
            }
            
        }
        else
        {
            canBerzerk = false;
            Stack.isCleaningBerzerk = false;
        }

        m_iProgressBarImage.fillAmount = berzerkValue / berzerkValueMax;

    }

    public static void BonusSweep(float bonusValue)
    {
        if (berzerkValue + bonusValue > berzerkValueMax)
        {
            berzerkValue = berzerkValueMax;
        }
        else
        {
            berzerkValue =+ bonusValue;
        }
    }
}
