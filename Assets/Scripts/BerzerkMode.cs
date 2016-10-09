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


    public float berzerkValue = 0f;
    public float berzerkValueMax = 100f;

    [SerializeField]
    private float m_fDeltaIncrementation;

    [SerializeField]
    private float m_fDeltaDecrementation;



    // Use this for initialization
    void Awake ()
    {
        m_iProgressBarImage = m_goProgressBar.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (berzerkValue < berzerkValueMax)
        {
            berzerkValue += m_fDeltaIncrementation;
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //spriteanim.stopCoroutine();
        if (berzerkValue >= m_fDeltaDecrementation)
        {
            if(Input.GetKey(KeyCode.Space))
            {
                berzerkValue -= m_fDeltaDecrementation;
                Stack.isCleaningBerzerk = true;
            }
            else
            {
                 Stack.isCleaningBerzerk = false;
            }

                //spriteanim.SecsPerFrame = animSpeedBerzerk;
                //spriteanim.PlayAnimation(animSpeedBerzerk);
            }
        else
        {
            Stack.isCleaningBerzerk = false;
        }
//else if (Input.GetKeyUp(KeyCode.Space))
//{
//   Stack.isCleaningBerzerk = false;
//spriteanim.SecsPerFrame = animSpeedNormal;
//spriteanim.PlayAnimation(animSpeedNormal);
//}


m_iProgressBarImage.fillAmount = berzerkValue / berzerkValueMax;
        Debug.Log(m_iProgressBarImage.fillAmount);

    }
}

