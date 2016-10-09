using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

/// <summary>
/// Timer.
/// </summary>
public class Score : MonoBehaviour
{
    /*[SerializeField]
    GameObject m_goRetry;

    private float m_tTime;

    private bool m_bIsStop;*/

    private float m_tCompteur;
    // Use this for initialization
    void Start()
    {
       /* m_goRetry.SetActive(false);
        m_tTime = 30f;
        m_bIsStop = false;*/
    }

    // Update is called once per frame
    void Update()
    {
        CalculTemps();
    }

    /// <summary>
    /// Calculs and displays the timer.
    /// </summary>
    private void CalculTemps()
    {
        m_tCompteur = Time.timeSinceLevelLoad;
        PlayerPrefs.SetFloat("score", m_tCompteur);
        /*float _fMinutes = m_tCompteur / 60f;
        float _fSecondes = m_tCompteur % 60f;*/

        int _fMinutes = Mathf.FloorToInt(m_tCompteur / 60F);
        int _fSecondes = Mathf.FloorToInt(m_tCompteur - _fMinutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", _fMinutes, _fSecondes);

        Debug.Log(_fMinutes);

        /*_fMinutes = Mathf.Max(_fMinutes, 0f);
        _fSecondes = Mathf.Max(_fSecondes, 0f);
        m_tCompteur = Mathf.Max(m_tCompteur, 0f);*/

        /*if (!m_bIsStop)
        {
            if (m_tCompteur == 0f)
            {
                m_bIsStop = true;

                m_goRetry.SetActive(true);
                Cible[] _cCibles = FindObjectsOfType<Cible>();

                Score _sScore = FindObjectOfType<Score>();
                _sScore.enabled = false;

                BestScore _bsBestScore = FindObjectOfType<BestScore>();
                _bsBestScore.enabled = false;

                for (int i = 0; i < _cCibles.Length - 1; i++)
                {
                    _cCibles[i].m_fLife = 0f;
                }

                Spawn _sSpawn = FindObjectOfType<Spawn>();
                _sSpawn.enabled = false;
            }
        }*/

        GetComponent<Text>().text = niceTime;//(String.Format("{0:00}:{1:00}", _fMinutes, _fSecondes));
    }
}
