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


    public float berzerkValue = 50;
    public float berzerkValueMax = 200;
    




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
            berzerkValue++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spriteanim.stopCoroutine();
            if (berzerkValue > 3)
            {
                berzerkValue -= 3;
                Stack.isCleaningBerzerk = true;
                //spriteanim.SecsPerFrame = animSpeedBerzerk;
                //spriteanim.PlayAnimation(animSpeedBerzerk);
            }
            else
            {
                Stack.isCleaningBerzerk = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Stack.isCleaningBerzerk = false;
            //spriteanim.SecsPerFrame = animSpeedNormal;
            //spriteanim.PlayAnimation(animSpeedNormal);
        }

        m_iProgressBarImage.fillAmount = berzerkValue / berzerkValueMax;
        Debug.Log(m_iProgressBarImage.fillAmount);

    }
}
